import http from "k6/http";
import { group, check } from "k6";
import { sleep } from "k6";
import {
  randomIntBetween,
  randomString,
  randomItem,
  uuidv4,
  findBetween,
} from "https://jslib.k6.io/k6-utils/1.1.0/index.js";

export const options = {
  vus: 10,
  duration: "30s",
  thresholds: {
    http_req_failed: ["rate<0.01"], // http errors should be less than 1%
    http_req_duration: ["p(95)<200"], // 95% of requests should be below 200ms
  },
};

const hostname = __ENV.HOSTNAME;
const sleepDuration = 0.1;

export default function () {
  group("API Health Check", healthCheck);
  group("Create Users", createUsers);
}

function healthCheck() {
  const url = `${hostname}/health`;
  const res = http.get(url);

  check(res, {
    "is status 200": (r) => r.status === 200,
    "is duration lower than 200ms": (r) => r.timings.duration <= 200,
  });

  sleep(sleepDuration);
}

function createUsers() {
  const url = `${hostname}/users`;
  const payload = JSON.stringify({
    firstName: randomItem(["Joe", "Jane"]),
    lastName: randomItem(["Robert", "Santos", "Lourenço"]),
    email: `user_${randomString(10)}@example.com`,
    password: "Abcd1234",
    confirmPassword: "Abcd1234",
    birthDate: "2021-06-03",
  });

  const params = {
    headers: {
      "Content-Type": "application/json",
    },
  };

  const res = http.post(url, payload, params);

  check(res, {
    "is status 201": (r) => r.status === 201,
    "is duration lower than 200ms": (r) => r.timings.duration <= 200,
  });

  sleep(sleepDuration);
}
