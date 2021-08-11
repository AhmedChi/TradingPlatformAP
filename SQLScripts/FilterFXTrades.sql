SELECT fx.fxTradeID, fx.baseNominal, fx.underlyingNominal, fx.baseQuotation, c1.currencyName AS 'Base Currency', c2.currencyName AS 'Underlying Currency'
FROM fxTrades AS fx
LEFT JOIN currencies AS c1
ON fx.baseCurrencyID = c1.currencyID
JOIN currencies c2
ON fx.underlyingCurrencyID = c2.currencyID
