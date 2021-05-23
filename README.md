# Crypto_Tracker
Windows Application to track cryptos

Application grabs coin price from CoinGecko using htmlAgility api
Then grabs coin data from text document containing coin data
Gets total value = current price * amount of coins
Gets profit (usd)
Stores that all in a text docuemnt in the following format:
 - Name: Current Price: Initial Value: Current Total value: Profit

Requires a text document that contains your coins data. Must be in the following format:
 - Name:TotalCoinAmount:InitialValue:
