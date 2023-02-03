const PROXY_CONFIG = [
  {
    context: [
      "users",
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
