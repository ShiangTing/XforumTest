const { default: store } = require("../store");

const errorHandle = (status, msg) => {
  switch(status) {
    case 400:
      console.log(msg);
      break;
    case 401:
      store.dispatch("setAuth",{
        token: "",
        isAuthorize: false
      })
      console.log(msg);
      break;
    case 403:
      console.log(msg);
      break;
    case 404:
        console.log(msg);
        break;
    default: 
      console.log("response:"+ msg);
  }
}