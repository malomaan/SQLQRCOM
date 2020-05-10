using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace SQLQRCOMCLS
{
	public class QRData
    {
		[Microsoft.SqlServer.Server.SqlProcedure]
		public static byte[] ImagenQR(string Dato)
		{
			int qrBackColor = Color.FromArgb(255, 255, 255, 255).ToArgb();
			int qrForeColor = Color.FromArgb(255, 0, 0, 0).ToArgb();
			QRCodeEncoder CodeQR = new QRCodeEncoder();
			CodeQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
			CodeQR.QRCodeScale = 2;
			CodeQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
			CodeQR.QRCodeVersion = 0;
			CodeQR.QRCodeScale = int.Parse("4");
			CodeQR.QRCodeBackgroundColor = Color.FromArgb(255, 255, 255, 255);
			CodeQR.QRCodeForegroundColor = Color.FromArgb(255, 0, 0, 0);
			Bitmap imageQR = CodeQR.Encode(Dato, Encoding.UTF8);
			MemoryStream ms = new MemoryStream();
			imageQR.Save(ms, ImageFormat.Jpeg);
			ImageConverter converter = new ImageConverter();
			return (byte[])converter.ConvertTo(imageQR, typeof(byte[]));
		}
	}
}
