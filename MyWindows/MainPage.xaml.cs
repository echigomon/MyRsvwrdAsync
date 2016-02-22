using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using RsvwrdAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_RsvwrdAsync rsvwrd;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            rsvwrd = new CS_RsvwrdAsync();

            textBox01.Text = "";
            textBox02.Text = "";

            ClearResultTextBox();			// 初期表示をクリアする
        }

        #region ［Ｒｓｖｗｒｄ］ボタン押下
        private async void button01_Click(object sender, RoutedEventArgs e)
        {   // [Rsvwrd]ボタン押下
            //            WriteLineResult("\n[Getken]ボタン押下");
            String KeyWord = textBox02.Text;

            
//            await rsvwrd.ClearAsync();
//            rsvwrd.Wbuf = textBlock02.Text;
            await rsvwrd.ExecAsync(KeyWord);
            WriteLineResult("\nResult :");
            if (rsvwrd.Rsv == true)
            {   // 予約語か？
                WriteLineResult(" True");
            }
            else
            {
                WriteLineResult(" False");
            }
            WriteLineResult("\n Kind : [{0}]", rsvwrd.RsvKind);
            WriteLineResult("\n Word : [{0}]", rsvwrd.Wbuf);
            if (rsvwrd.Is_class == true)
            {   // [Class]検出？
                WriteLineResult("\n Find : [Class]");
                rsvwrd.Is_class = false;
            }
            if (rsvwrd.Is_namespace == true)
            {   // [Namespace]検出？
                WriteLineResult("\n Find : [Namespace]");
                rsvwrd.Is_namespace = false;
            }
            if (rsvwrd.Is_func == true)
            {   // [Function]検出？
                WriteLineResult("\n Find : [Function]");
                WriteLineResult("\n Pos : [{0}]", rsvwrd.Pos);
                rsvwrd.Is_func = false;
            }
        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private void button02_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();			// 初期表示をクリアする

            textBox01.Text = "";
            textBox02.Text = "";
        }
        #endregion
    }
}
