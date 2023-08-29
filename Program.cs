// See https://aka.ms/new-console-template for more information
using QRCoder;
using static QRCoder.PayloadGenerator;

Console.WriteLine("Hello, World!");


var generator = new Url("https://github.com/codebude/QRCoder/");
var payload = generator.ToString();

var qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
var qrCode = new SvgQRCode(qrCodeData);
var qrCodeAsBitmap = qrCode.GetGraphic(20);
