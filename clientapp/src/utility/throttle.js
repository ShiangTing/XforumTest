function throttle(callback, delay) {
  var timeoutHandler = null;
  return function () {
      if (timeoutHandler == null) {
          timeoutHandler = setTimeout(function () {
              callback();
              clearInterval(timeoutHandler);
              timeoutHandler = null;
          }, delay);
      }else{
        clearInterval(timeoutHandler)
      }
  }
}



export default throttle;
