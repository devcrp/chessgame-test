const Api = {
  baseUrl:
    process.env.NODE_ENV === "production"
      ? "https://chessgame1.azurewebsites.net"
      : "https://localhost:44386",
};

export default Api;
