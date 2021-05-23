using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;



namespace Crypto_Tracker
{
    public partial class Form1 : Form
    {   
        // url : https://www.coingecko.com/en/coins/
        

        private List<Coin> coins = new List<Coin>();
        private DateTime today;
        private double totalProfit = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //coin object because c#
        public class Coin
        {
            string coinName;         
            double coinCurrentPrice;
            double totalCoinCount;
            int intialTotalCoinCountValue;
            
            public Coin(string coinName, double coinCurrentPrice, double totalCoinCount, int intialTotalCoinCountValue)
            {
                this.coinName = coinName; 
                this.coinCurrentPrice = coinCurrentPrice;
                this.intialTotalCoinCountValue = intialTotalCoinCountValue;
                this.totalCoinCount = totalCoinCount;
            }
            public string getName()
            {
                return this.coinName;
            }
            public double getCurrentPrice()
            {
                return this.coinCurrentPrice;
            }
            public double getTotalCoins()
            {
                return this.totalCoinCount;
            }
            public int getintialTotalCoinCountValue()
            {
                return this.intialTotalCoinCountValue;
            }
            public double getCurrentTotalCoinCountValue()
            {
                return (Math.Round((this.coinCurrentPrice * this.totalCoinCount), 2));
            }
        }

        //Add break points
        public string CryptoScrapper(string x)
        {
            string src = "https://www.coingecko.com/en/coins/";
            try
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(src + x);
                try
                {
                    var price = doc.DocumentNode.SelectNodes("//span[@class='no-wrap']").ToList();
                    foreach (var item in price)
                    {
                        //Console.WriteLine(x.ToUpper() + ": " + item.InnerText);
                        return item.InnerText.ToString();
                        
                    }              
                }
                catch(Exception e)
                {
                    Console.WriteLine("Failed to acces the price of: " + x + e);
                    
                    return x.ToUpper() + "0";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("not page found : " + (src+x) + e);
                return x.ToUpper() + "0"; 
            }
            return x.ToUpper() + "0";
        }
        public void PopulateObjectCoin( string[] coinNames)
        {
            try
            {
                for (int i = 0; i < coinNames.Length - 1; i += 3)
                {

                    //Console.WriteLine(coinNames[i] + " " + );
                    coins.Add(new Coin(coinNames[i], Convert.ToDouble(CryptoScrapper(coinNames[i]).Trim().Trim('$')), Convert.ToDouble(coinNames[i + 1]), Convert.ToInt32(coinNames[i + 2])));
                }
            }
            catch(Exception e)
            {
                Console.Write("Failed to 'PopulateObjectCoin'" + e.ToString());
            }
        }

        //this retrieves data of the coin
        public string[] RetieveCoinsFromDoc()
        {
            try
            {
                string incomingLine;
                string builtLine;
                StreamReader sr = new StreamReader(File location of where your coin data is stored);
                incomingLine = sr.ReadLine();
                builtLine = incomingLine;
                while (incomingLine != null)
                {
                    incomingLine = sr.ReadLine();
                    builtLine += incomingLine;
                }

                sr.Close();

                string[] fromDocCoinDataSplit = builtLine.Split(':');

                return fromDocCoinDataSplit;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to retrive coin data from document. Exception: " + e.Message);
                return null;
            }
        }

        public void WriteCoinDatatoDoc()
        {
            try
            {

                StreamWriter sw =  new StreamWriter(File location of where you want to store the computed coin data, true);
                

                sw.WriteLine(today.ToString());
                foreach (Coin coin in coins)
                {
                    totalProfit += Math.Round((coin.getCurrentTotalCoinCountValue() - coin.getintialTotalCoinCountValue()), 2);
                    sw.WriteLine(coin.getName().ToUpper() + ": Price: $" + coin.getCurrentPrice() + " Amount: " + coin.getTotalCoins() +  " Total Intial Value: $" + coin.getintialTotalCoinCountValue() +" Total Current Value: $"+  coin.getCurrentTotalCoinCountValue() + " Profit: $" + Math.Round((coin.getCurrentTotalCoinCountValue() - coin.getintialTotalCoinCountValue()), 2));
                    WriteCoinDataToPrompt((coin.getName().ToUpper() + ": Price: $" + coin.getCurrentPrice() + " Amount: " + coin.getTotalCoins() + " Total Intial Value: $" + coin.getintialTotalCoinCountValue() + " Total Current Value: $" + coin.getCurrentTotalCoinCountValue() + " Profit: $" + Math.Round((coin.getCurrentTotalCoinCountValue() - coin.getintialTotalCoinCountValue()), 2)).ToString());
                }
                sw.WriteLine("Total Profit: $"  + totalProfit);
                WriteCoinDataToPrompt("Total Profit: $" + totalProfit);
                sw.WriteLine(".");
                coins.Clear();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void WriteCoinDataToPrompt(string coinData)
        {
            try
            {
                coinDataTB.AppendText(coinData);
                coinDataTB.AppendText(Environment.NewLine);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to populate prompt. Exception: " + e);
            }


        }

        
        private void onBT_Click(object sender, EventArgs e)
        {
            today = DateTime.Now;
            Console.WriteLine(today.ToString());
            PopulateObjectCoin(RetieveCoinsFromDoc());
            WriteCoinDatatoDoc();


        }

        private void offBt_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}

