const errorHandle = function(status, msg) {
  switch (status) {
    case '200':
      console.log("訊息:" + msg)
      break;
    case '401':
      console.log('登入驗證錯誤:' + msg);
      break;
    case '404':
      console.log('使用者錯誤:' + msg);
      break;
    case '403':
      console.log('使用者驗證錯誤:' + msg);
      break;
    case '500':
      console.log('伺服器錯誤:' + msg);
      break;
    default:
      console.log('未知錯誤:' + msg);
      break;
  }
};
export default errorHandle;
