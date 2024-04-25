using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


[System.Serializable]
public class Crypto
{
    public string id;
    public string rank;
    public string symbol;
    public string name;// Bitcoin,
    public string supply;// 19685775.0000000000000000,
    public string maxSupply;// 21000000.0000000000000000,
    public string marketCapUsd;// 1269717069277.7593478366775225,
    public string volumeUsd24Hr;// 7333569009.5239704225778229,
    public string priceUsd;// 64499.2167835789725239,
    public string changePercent24Hr;// -3.2261407766878432,
    public string vwap24Hr;// 66341.6741912098635973,
    public string explorer;// https//blockchain.info/

    public Crypto(string id, string rank, string symbol, string name, string supply, string maxSupply, string marketCapUsd, string volumeUsd24Hr, string priceUsd, string changePercent24Hr, string vwap24Hr, string explorer)
    {
        this.id = id;
        this.rank = rank;
        this.symbol = symbol;
        this.name = name;
        this.supply = supply;
        this.maxSupply = maxSupply;
        this.marketCapUsd = marketCapUsd;
        this.volumeUsd24Hr = volumeUsd24Hr;
        this.priceUsd = priceUsd;
        this.changePercent24Hr = changePercent24Hr;
        this.vwap24Hr = vwap24Hr;
        this.explorer = explorer;
    }
}

