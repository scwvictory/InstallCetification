using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace InstallCetification
{
    class Program
    {
        static void Main(string[] args)
        {
            //開始
            Console.WriteLine("--------- 処理開始 ---------");

            //引数で渡された証明書ファイルをインストールする
            for (int i = 0; i < args.Length; i++)
            {
                var path = args[i];
                if (File.Exists(path))
                {
                    //ファイルが存在する場合のみ、処理を実行
                    try
                    {
                        SetCertification(path);
                        //コンソール上にインストールしたパスを出力
                        Console.WriteLine("'" + path + "' is imported.");
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }
                else
                {
                    //ファイルがない場合
                    Console.WriteLine("'" + path + "' is not found.");
                }
            }

            //開始
            Console.WriteLine("--------- 処理終了 ---------");
        }

        static void SetCertification(string path)
        {
            try
            {
                //証明書をインストールするストア
                var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                //インストールする証明書
                var cerFile = new X509Certificate2(path);
                //ストアを開く
                store.Open(OpenFlags.ReadWrite);
                store.Add(cerFile);
                store.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
