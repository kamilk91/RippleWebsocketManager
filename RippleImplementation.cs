using System;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace RippleType
{
    class RippleImplementation
    {
        public RippleImplementation(string nodeAddress, bool debugger = false)
        {
            this.NodeAddress = nodeAddress;
            this.debug = debugger;
        }
        /*
         * 
         * TODO: 
         * offline signing
         * ripple_path_find
         * path_find
         * book_offers
         * 
         */

        public string NodeAddress;
        public static Queue<string> requests = new Queue<string>();
        public bool debug = false;
        public enum methods
        {
            account_tx,
            account_info,
            account_lines,
            account_offers,
            account_currencies,
            tx,
            tx_history,
            sign_and_submit,
            server_info,
            server_state,
            ping,
            subscribe,
            unsubscribe,
            ledger,
            ledger_closed,
            ledger_current,
            ledger_entry,
            transaction_entry
            
        };

        public string DoString(methods method, string start = "10", string transaction = null, int ledger_index_int = 1, string tx_hash = null, int account_index = 0, string strict = "false", string ledger = null, string account = null, int ledger_index_min = -1, int ledger_index_max = -1, string binary = "false", int count = 10, int limit = 10, string forward = "false", string destination = null, long value = 0, string secret = null, long fee = 1000, string[] accounts = null, string[] streamMethods = null, string type = null, string account_root = null, string ledger_index = null )
        {

            switch (method)
            {

                case methods.tx_history:
                    return "{\"id\":7," +
                        "\"command\":\"tx_history\"," +
                        "\"start\":"+start+"}";
                case methods.server_info:
                    return
                        "{" +
                        "\"command\":\"server_info\"" +
                        "}";
                case methods.server_state:
                    return
                        "{" +
                        "\"command\":\"server_state\"" +
                        "}";
                case methods.ping:
                    return "{" +
                        "\"command\":\"ping\"" +
                        "}";
                case methods.subscribe:
                    List<string> ListOfAccounts = new List<string>();
                    List<string> ListOfMethods = new List<string>();

                    foreach (string singleAccount in accounts)
                    {
                        ListOfAccounts.Add("\"" + singleAccount + "\"");
                    }
                    var accResult = String.Join(", ", ListOfAccounts.ToArray());

                    foreach (string singleMethod in streamMethods)
                    {
                        ListOfMethods.Add("\"" + singleMethod + "\"");
                    }
                    var methodsResult = String.Join(", ", ListOfMethods.ToArray());
                    if(ListOfAccounts.Capacity == 0)
                    {
                        return 
                            "{" +
                            "\"id\":2," +
                            "\"command\":\"subscribe\"," +
                            "\"accounts\":[]," +
                            "\"streams\":[" + methodsResult + "]" +
                            "}";

                    }
                        return 
                        "{" +
                        "\"id\":2," +
                        "\"command\":\"subscribe\"," +
                        "\"accounts\":[" + accResult + "]," +
                        "\"streams\":["+ methodsResult + "]" +
                        "}";

                case methods.unsubscribe:
                    List<string> UnListOfAccounts = new List<string>();
                    List<string> UnListOfMethods = new List<string>();

                    foreach (string singleAccount in accounts)
                    {
                        UnListOfAccounts.Add("\"" + singleAccount + "\"");
                    }
                    var UnaccResult = String.Join(", ", UnListOfAccounts.ToArray());

                    foreach (string singleMethod in streamMethods)
                    {
                        UnListOfMethods.Add("\"" + singleMethod + "\"");
                    }
                    var UnmethodsResult = String.Join(", ", UnListOfMethods.ToArray());
                    if (UnListOfAccounts.Capacity == 0)
                    {
                        return
                            "{" +
                            "\"id\":2," +
                            "\"command\":\"subscribe\"," +
                            "\"accounts\":[]," +
                            "\"streams\":[" + UnmethodsResult + "]" +
                            "}";

                    }
                    return
                    "{" +
                    "\"id\":2," +
                    "\"command\":\"subscribe\"," +
                    "\"accounts\":[" + UnaccResult + "]," +
                    "\"streams\":[" + UnmethodsResult + "]" +
                    "}";

                case methods.account_info:
                    return 
                        "{" +
                        "\"command\":\"account_info\"," +
                        "\"account\":\"" + account + "\"" +
                        "}";
                case methods.sign_and_submit:
                    return "{" +
                        "\"id\":2," +
                        "\"command\":\"submit\"," +
                        "\"tx_json\":" +
                            "{\"TransactionType\":\"Payment\"," +
                            "\"Account\":\"" + account + "\"," +
                            "\"Destination\":\"" + destination + "\"," +
                            "\"Amount\":" +
                                "{\"" +
                                "currency\":\"XRP\"," +
                                "\"value\":" + value + "," +
                                "\"issuer\":\"" + account + "\"" +
                                "}}," +
                            "\"secret\":\"" + secret + "\"," +
                            "\"offline\":false," +
                            "\"fee_mult_max\":" + fee + "}";
                case methods.ledger:
                    return "{" +
                        "\"id\":7," +
                        "\"command\":\"ledger\"," +
                        "\"full\":false," +
                        "\"expand\":false," +
                        "\"transactions\":true," +
                        "\"accounts\":true" +
                        "}";
                case methods.ledger_closed:
                    return "{" +
                        "\"command\":\"ledger_closed\"" +
                        "}";
                case methods.ledger_current:
                    return "{" +
                        "\"command\":\"ledger_current\"" +
                        "}";
                case methods.ledger_entry:
                    return "{" +
                        "\"id\":7," +
                        "\"command\":\"ledger_entry\"," +
                        "\"type\":\""+type+"\"," +
                        "\"account_root\":" +
                        "\""+account_root+"\"," +
                        "\"ledger_index\":\""+ledger_index+"\"}";
                case methods.account_lines:
                    return "{\"id\":7," +
                        "\"command\":\"account_lines\"," +
                        "\"account\":\""+account+"\"," +
                        "\"ledger\":\""+ledger+"\"}";
                case methods.account_offers:
                    return "{\"id\":7," +
                        "\"command\":\"account_offers\"," +
                        "\"account\":\""+account+"\"," +
                        "\"ledger\":\""+ledger+"\"}";
                case methods.account_currencies:
                    return "{\"id\":7," +
                        "\"command\":\"account_currencies\"," +
                        "\"account\":\""+account+"\"," +
                        "\"strict\":"+strict+"," +
                        "\"ledger_index\":\""+ledger_index+"\"," +
                        "\"account_index\":"+account_index+"}";
                case methods.transaction_entry:
                    return "{\"id\":7," +
                        "\"command\":\"transaction_entry\"," +
                        "\"tx_hash\":\"" + tx_hash + "\"," +
                        "\"ledger_index\":" + ledger_index_int + "}";
                case methods.account_tx:
                    return 
                        "{" +
                        "\"command\":\"account_tx\"," +
                        "\"account\":\"" + account + "\"," +
                        "\"ledger_index_min\": " + ledger_index_min + "," +
                        "\"ledger_index_max\": " + ledger_index_max + "," +
                        "\"binary\":" + binary + "," +
                        "\"count\": " + count + "," +
                        "\"limit\":" + limit + "," +
                        "\"forward\": " + forward + "" +
                        "}";
                case methods.tx:
                    return "{\"id\":7,\"command\":\"tx\",\"transaction\":\""+transaction+"\"}";


            }

            return null;
        }
        public void RipplePing(methods method = methods.ping)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }
        public void RippleTXHistory(methods method = methods.tx_history,string start = "10")
        {
            string Request = DoString(method: method, start:start);
            requests.Enqueue(Request);
        }
        public void RippleServerState(methods method = methods.server_state)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }
        public void RippleServerInfo(methods method = methods.server_info)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }
        public void RippleTX(methods method = methods.tx, string transaction = null)
        {
            string Request = DoString(method: methods.tx, transaction: transaction);
            requests.Enqueue(Request);
        }
        public void RippleAccountTX(methods method = methods.account_tx, string account = null, int ledger_index_min = 0, int ledger_index_max = 0,string binary = "false", int count = 10, int limit = 10, string forward = "false" )
        {
            string Request = DoString(method: method, account: account, ledger_index_min: ledger_index_min, ledger_index_max: ledger_index_max, binary: binary, count: count, limit: limit, forward: forward);
            requests.Enqueue(Request);
        }

        public void RippleTransactionEntry(methods method = methods.transaction_entry, string tx_hash = null, int ledger_index_int=1)
        {
            string Request = DoString(method: method, tx_hash: tx_hash, ledger_index_int: ledger_index_int);
            requests.Enqueue(Request);
        }
        public void RippleAccountCurrencies(methods method = methods.account_currencies, string account = null, string strict = "false", string ledger_index = "validated", int account_index = 1)
        {
            string Request = DoString(method: method, account: account, strict: strict, ledger_index: ledger_index);
            requests.Enqueue(Request);
        }

        public void RippleAccountOffers(methods method = methods.account_offers, string account = null, string ledger = null)
        {
            string Request = DoString(method: method, account: account, ledger: ledger);
            requests.Enqueue(Request);
        }
        public void RippleAccountLines(methods method = methods.account_lines, string account = null, string ledger = null)
        {
            string Request = DoString(method: method, account: account, ledger: ledger);
            requests.Enqueue(Request);

        }
        public void RippleLedgerEntry(methods method = methods.ledger_entry, string type = null, string account_root = null, string ledger_index = null)
        {
            string Request = DoString(method: method, type: type, account_root: account_root, ledger_index: ledger_index);
            requests.Enqueue(Request);
        }
        public void RippleLedgerCurrent(methods method = methods.ledger_current)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }
        public void RippleLedgerClosed(methods method = methods.ledger_closed)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }

        public void RippleLedger(methods method = methods.ledger)
        {
            string Request = DoString(method: method);
            requests.Enqueue(Request);
        }


        public void RippleSubscribe(methods method = methods.subscribe, string[] accounts = null, string[] methods = null)
        {
            string Request = DoString(method: method, accounts:accounts, streamMethods:methods);
            requests.Enqueue(Request);
        }

        public void RippleUnSubscribe(methods method = methods.subscribe, string[] accounts = null, string[] methods = null)
        {
            string Request = DoString(method: method, accounts: accounts, streamMethods: methods);
            requests.Enqueue(Request);
        }



        public void RippleSendTransaction(methods method = methods.sign_and_submit, string account = null, string secret = null, long value = 0, string destination = null )
        {

            string Request = DoString(method: method, account: account, secret: secret, value: value, destination: destination);
            requests.Enqueue(Request);
        }

        public void RippleAccountInfo(methods method = methods.account_info, string account=null)
        {
         
            string Request = DoString(method: method, account: account);
            requests.Enqueue(Request);
             
        }

        public JObject JsonToNormal(string JsonString)
        {
            JObject json = JObject.Parse(JsonString);
            if(this.debug)
            {

            Console.WriteLine(json);
            }
            return json;
        }


        public void RippleSocketRun()
        {
            
            using (var ws = new WebSocket(this.NodeAddress))
            {
                ws.OnOpen += (sender,e) => Console.WriteLine("Socket open.");
                ws.OnMessage += (sender, e)
                    => JsonToNormal(e.Data);
                
                
                ws.Connect();
                while (true)
                {
                    if (requests.Count > 0)
                    {

                        foreach(string request in requests.ToArray())
                        {
                           
                            ws.Send(requests.Dequeue());
                            
                        }
                    }
                }
            }
        }
    }
}




