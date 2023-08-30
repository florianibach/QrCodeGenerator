using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using QRCoder;
using static QRCoder.PayloadGenerator;
using static QRCoder.SvgQRCode;

Console.WriteLine("Hello, World!");


var url = new Url("https://youtu.be/gkDRHvjcypY?si=PCq-KjOYrxA8n7ir");

var qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode($"{url}", QRCodeGenerator.ECCLevel.Q);
var qrCode = new SvgQRCode(qrCodeData);
var svr = await File.ReadAllBytesAsync(@"D:\temp\jer.svg");
var bitmap = new Bitmap(@"D:\temp\jer_stift.png");
var svgLogo = new SvgLogo(bitmap, iconSizePercent: 50, fillLogoBackground: false);
var qrCodeAsImage = qrCode.GetGraphic(20, Color.White, Color.Black, drawQuietZones: true, logo: null);
await WriteToFileAsync(qrCodeAsImage);

Console.WriteLine("finished");
Console.ReadKey();

static async Task WriteToFileAsync(string qrCode)
{
    await using var outputFile = new StreamWriter(Path.Combine(@"D:\share", "QrCode.svg"));
    await outputFile.WriteAsync(qrCode);
}