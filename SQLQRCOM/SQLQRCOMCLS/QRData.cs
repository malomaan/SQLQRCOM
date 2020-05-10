using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

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
