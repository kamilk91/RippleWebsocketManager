# Warning

**Never use your Private Key (seed, hash, whatever) when connected to public node!**

# RippleWebsocketManager
wrapper for ripple methods. Version 1.0.0 Allows you to watch only (when you enable **debugger:true** in creating new instance). Please be patient to wrapper, or use source code to fetch data. From my side data fetcher will be available in days.  

# NugetPackageManager
- [Use this url to check NuggetPackage Store](https://www.nuget.org/packages/RippleSocketManager/ "Use this url to check NuggetPackage Store")
- ```Install-Package RippleSocketManager -Version 1.0.0	```
- ```dotnet add package RippleSocketManager --version 1.0.0	```
- ```paket add RippleSocketManager --version 1.0.0```

# Usage
```
RippleImplementation xrp = new RippleImplementation("wss://s.altnet.rippletest.net:51233", debugger:true);
xrp.RippleAccountInfo(account: "rippleaccount");
```
Will connect you to Ripple websocket based on Ripple Testnet. Where rippleaccount please provide your account.  

# Available methods
- account_tx 
-  account_info 
-  account_lines 
-  account_offers 
-  account_currencies 
-  tx 
-  tx_history 
-  sign_and_submit 
-  server_info 
-  server_state 
-  ping 
-  subscribe 
-  unsubscribe 
-  ledger 
-  ledger_closed 
-  ledger_current 
-  ledger_entry 
-  transaction_entry 
