SELECT cp.counterpartyName, eq.equityCode, eq.equityPrice, eq.equityVariance, c.currencyCode, t.tradeQuantity, t.tradeTotal, t.dealPrice
FROM equities AS eq
LEFT JOIN counterparties AS cp
ON eq.counterpartyID = cp.counterpartyID
LEFT JOIN currencies AS c
ON eq.currencyID = c.currencyID
LEFT JOIN trades AS t
ON eq.counterpartyID = t.counterpartyID
ORDER BY cp.counterpartyName