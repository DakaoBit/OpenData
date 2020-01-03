using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Application.Services.Security
{
	/// <summary>
	/// HMAC認證授權機制
	/// 
	/// HMAC機制：以HMAC簽章驗證使用者的身份，用戶在請求API服務時，
	/// 將APP Key 與當下時間（格式請使用GMT時間）做HMAC-SHA1 運算後轉成Base64 格式，
	/// 帶入signature屬性欄位，服務器端將驗證用戶請求時的header欄位(詳如第四點)，
	/// 驗證使用者的身份及請求服務的時效性。
	/// 
	/// </summary>
	public class HMAC_SHA1
	{
		/// <summary>
		/// HMAC Signature簽章
		/// 
		/// HMAC Signature簽章時效性：於MOTC Helper 該網頁測試時，
		/// 請在最上方輸入 API Key 與 API ID
		/// （請再次確認是否有把APP Key跟ID填寫正確，若欄位資訊相反會無法執行）。 
		/// 點選Explore ，每次請求下方API時，會於header 帶入Authorization 及 x-date 
		/// ，依照請求當下的時間 & API Key 製作簽章。
		/// </summary>
		/// <param name="xDate"></param>
		/// <param name="AppKey"></param>
		/// <param name="inputCharset"></param>
		/// <returns></returns>
		public static string Signature(string xDate, string AppKey, string inputCharset = "utf-8")
		{
			Encoding _encode = Encoding.GetEncoding(inputCharset);
			byte[] _byteData = Encoding.GetEncoding(inputCharset).GetBytes(xDate);
			HMACSHA1 _hmac = new HMACSHA1(_encode.GetBytes(AppKey));

			using (CryptoStream _cs = new CryptoStream(Stream.Null, _hmac, CryptoStreamMode.Write))
			{
				_cs.Write(_byteData, 0, _byteData.Length);
			}
			return Convert.ToBase64String(_hmac.Hash);
		}
	}
}
