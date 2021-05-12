// var eleUploadFile = document.getElementById("uploadFile");
//   var eleImgUploadX = document.getElementById("imgUploadX");
//     eleUploadFile.addEventListener("change", function(event) {
//       var reader = new FileReader();
//       var file = event.target.files[0] || event.dataTransfer.files[0];
//       reader.onload = function(e) {
//         var base64 = e.target.result;

//           // 使用canvas合成图片，并base64化
//           imgTogether(base64, function(url) {
//             // 尺寸

//             // 预览
//             event.target.files[0] = url;
//             // eleImgUploadX.innerHTML = '<img ref="myimg" src="' + url + '" width="' + 648 + '" height="' + 1404 + '">';
//             eleImgUploadX.innerHTML = '<img id="myimg" src="' + url + '" width="' + 648 + '" height="' + 1404 + '">';
//           });

//       };
//       reader.readAsDataURL(file);
//     });
export default {
  // canvas图片合成
  imgTogether(url, callback) {
    var canvas = document.createElement("canvas");

    canvas.width = 648;
    canvas.height = 1404;

    var context = canvas.getContext("2d");

    // 这是上传图像
    var imgUpload = new Image();
    imgUpload.setAttribute("crossOrigin", "Anonymous");
    imgUpload.onload = function() {
      // 绘制
      //context.drawImage(imgUpload, 0, 0, size, size, 0, 0, 720, 1080);
      context.drawImage(imgUpload, 0, 0, 648, 1404);
      // 再次绘制
      var imgname = document.getElementById("name").value;
      context.font = "50px Verdana";
      context.fillStyle = "red";
      context.fillText(imgname, 10, 50, 250);
      // 回调
      callback(canvas.toDataURL("image/png"));
    };
    imgUpload.src = url;
  }
};
//   var a = 100;
//   var b = 100;
//   var g = 100;
//   var mya = 0;
//   var myb = 0;
//   var myg = 0;
//   var myVar = setInterval(function() {
//     myTimer();
//   }, 100);
//   function myTimer() {
//     if (mya != a && myb != b && myg != g) {
//       if (a > mya) {
//         mya = mya + 1;
//         // document.getElementById("m1").innerText = a+" "+ mya;
//       } else mya--;
//       if (b > myb) {
//         myb = myb + 1;
//         // document.getElementById("m2").innerText =b+" "+ myb;
//       } else myb--;
//       if (g > myg) {
//         myg = myg + 1;
//         //document.getElementById("m3").innerText =g+" "+ myg;
//       } else myg--;
//       //变化颜色
//       document.getElementById("tit").style.color =
//         "rgb(" + mya + "," + myb + ", " + myg + ")";
//     } else {
//       der();
//     }
//   }
//   function der() {
//     a = Math.floor(Math.random() * 256);
//     b = Math.floor(Math.random() * 256);
//     g = Math.floor(Math.random() * 256);
//   }
