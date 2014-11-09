GzipSimplSharp
==============

A Crestron Simpl# library to enable gzip decoding in SIMPL+

Usage
-----

In SIMPL+:

```
#USER_SIMPLSHARP_LIBRARY "GzipSimplSharp"

CHANGE RX$
{
  Gzip gzip;
  STRING ungzipped[4096];
  ungzipped = gzip.Decompress(RX$);
  // ...
}

```

License
-------

[MIT](/LICENSE)

Author
------

Marshall Roch <<marshall@mroch.com>>
