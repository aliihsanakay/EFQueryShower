
# EfQueryShower

c# içerisinde ef kullanılan projelerde .ToQueryString methodu ile db tarafında çalıştırılacak 
sorgu alınır ve içerisindeki parametreleri bu proje ile otomatik olarak yerleştirilir.



## Örnek Oluşan Sorgu

```sql

-- @__ef_filter__p_3='False'

-- @__ef_filter__p_4='False'

-- @__ef_filter__CurrentTenantId_5='1' (Nullable = true)

-- @__input_CategoryId_1='6' (Nullable = true)

-- @__ef_filter__p_6='False'

-- @__ef_filter__p_7='False'

-- @__ef_filter__CurrentTenantId_8='1' (Nullable = true)

-- @__ef_filter__p_9='False'

-- @__ef_filter__p_10='False'

-- @__ef_filter__CurrentTenantId_11='1' (Nullable = true)

-- @__ef_filter__p_12='False'

-- @__ef_filter__p_13='False'

-- @__ef_filter__CurrentTenantId_14='1' (Nullable = true)

-- @__ef_filter__p_0='False'

-- @__ef_filter__p_1='False'

-- @__ef_filter__CurrentTenantId_2='1' (Nullable = true)

-- @__input_CreationTime_0='2021-09-10T03:00:00.0000000+03:00' (Nullable = true) (DbType = DateTime)

SELECT p."Id", p."Barcode", p."BrandId", p."CargoStatus", p."Code", p."CreationTime", p."CreatorUserId", p."DeleterUserId", p."DeletionTime", p."Desi", p."Explanation", p."GroupId", p."InvoiceName", p."IsDeleted", p."JsonItem", p."LastModificationTime", p."LastModifierUserId", p."MinOrderQuantity", p."Name", p."Quantity", p."Source", p."SourceId", p."Status", p."TenantId", p."VatRate", t."Id", t0."Id", t1."Id", t1."CreationTime", t1."CreatorUserId", t1."Currency", t1."DeleterUserId", t1."DeletionTime", t1."IsDeleted", t1."LastModificationTime", t1."LastModifierUserId", t1."Price", t1."PriceNumber", t1."ProductCode", t1."ProductId", t1."TenantId", t1."Type", t2."Id", t2."CreationTime", t2."CreatorUserId", t2."DeleterUserId", t2."DeletionTime", t2."IsDeleted", t2."LastModificationTime", t2."LastModifierUserId", t2."Name", t2."Path", t2."ProductId", t2."Sort", t2."TenantId"
FROM "Product" AS p

INNER JOIN (
    SELECT p0."Id", p0."ProductId"
    FROM "ProductCategory" AS p0
    WHERE ((@__ef_filter__p_3 OR NOT (p0."IsDeleted")) AND (@__ef_filter__p_4 OR (p0."TenantId" = @__ef_filter__CurrentTenantId_5))) AND (p0."CategoryId" = @__input_CategoryId_1)
) AS t ON p."Id" = t."ProductId"

LEFT JOIN (
    SELECT p1."Id", p1."ProductId"
    FROM "ProductMarketPlaceMap" AS p1
    WHERE (@__ef_filter__p_6 OR NOT (p1."IsDeleted")) AND (@__ef_filter__p_7 OR (p1."TenantId" = @__ef_filter__CurrentTenantId_8))
) AS t0 ON p."Id" = t0."ProductId"

LEFT JOIN (
    SELECT p2."Id", p2."CreationTime", p2."CreatorUserId", p2."Currency", p2."DeleterUserId", p2."DeletionTime", p2."IsDeleted", p2."LastModificationTime", p2."LastModifierUserId", p2."Price", p2."PriceNumber", p2."ProductCode", p2."ProductId", p2."TenantId", p2."Type"
    FROM "ProductPrice" AS p2
    WHERE (@__ef_filter__p_9 OR NOT (p2."IsDeleted")) AND (@__ef_filter__p_10 OR (p2."TenantId" = @__ef_filter__CurrentTenantId_11))
) AS t1 ON p."Id" = t1."ProductId"

LEFT JOIN (
    SELECT p3."Id", p3."CreationTime", p3."CreatorUserId", p3."DeleterUserId", p3."DeletionTime", p3."IsDeleted", p3."LastModificationTime", p3."LastModifierUserId", p3."Name", p3."Path", p3."ProductId", p3."Sort", p3."TenantId"
    FROM "ProductPicture" AS p3
    WHERE (@__ef_filter__p_12 OR NOT (p3."IsDeleted")) AND (@__ef_filter__p_13 OR (p3."TenantId" = @__ef_filter__CurrentTenantId_14))
) AS t2 ON p."Id" = t2."ProductId"

WHERE ((@__ef_filter__p_0 OR NOT (p."IsDeleted")) AND (@__ef_filter__p_1 OR (p."TenantId" = @__ef_filter__CurrentTenantId_2))) AND (p."CreationTime" >= @__input_CreationTime_0)

ORDER BY p."Id", t."Id", t0."Id", t1."Id", t2."Id"
```

  

  
## Örnek Çıktı

```sql
  
SELECT p."Id", p."Barcode", p."BrandId", p."CargoStatus", p."Code", p."CreationTime", p."CreatorUserId", p."DeleterUserId", p."DeletionTime", p."Desi", p."Explanation", p."GroupId", p."InvoiceName", p."IsDeleted", p."JsonItem", p."LastModificationTime", p."LastModifierUserId", p."MinOrderQuantity", p."Name", p."Quantity", p."Source", p."SourceId", p."Status", p."TenantId", p."VatRate", t."Id", t0."Id", t1."Id", t1."CreationTime", t1."CreatorUserId", t1."Currency", t1."DeleterUserId", t1."DeletionTime", t1."IsDeleted", t1."LastModificationTime", t1."LastModifierUserId", t1."Price", t1."PriceNumber", t1."ProductCode", t1."ProductId", t1."TenantId", t1."Type", t2."Id", t2."CreationTime", t2."CreatorUserId", t2."DeleterUserId", t2."DeletionTime", t2."IsDeleted", t2."LastModificationTime", t2."LastModifierUserId", t2."Name", t2."Path", t2."ProductId", t2."Sort", t2."TenantId"
FROM "Product" AS p
INNER JOIN (
    SELECT p0."Id", p0."ProductId"
    FROM "ProductCategory" AS p0
    WHERE (('False' OR NOT (p0."IsDeleted")) AND ('False' OR (p0."TenantId" = '1'))) AND (p0."CategoryId" = '6')
) AS t ON p."Id" = t."ProductId"
LEFT JOIN (
    SELECT p1."Id", p1."ProductId"
    FROM "ProductMarketPlaceMap" AS p1
    WHERE ('False' OR NOT (p1."IsDeleted")) AND ('False' OR (p1."TenantId" = '1'))
) AS t0 ON p."Id" = t0."ProductId"
LEFT JOIN (
    SELECT p2."Id", p2."CreationTime", p2."CreatorUserId", p2."Currency", p2."DeleterUserId", p2."DeletionTime", p2."IsDeleted", p2."LastModificationTime", p2."LastModifierUserId", p2."Price", p2."PriceNumber", p2."ProductCode", p2."ProductId", p2."TenantId", p2."Type"
    FROM "ProductPrice" AS p2
    WHERE ('False' OR NOT (p2."IsDeleted")) AND ('False' OR (p2."TenantId" = '1'))
) AS t1 ON p."Id" = t1."ProductId"
LEFT JOIN (
    SELECT p3."Id", p3."CreationTime", p3."CreatorUserId", p3."DeleterUserId", p3."DeletionTime", p3."IsDeleted", p3."LastModificationTime", p3."LastModifierUserId", p3."Name", p3."Path", p3."ProductId", p3."Sort", p3."TenantId"
    FROM "ProductPicture" AS p3
    WHERE ('False' OR NOT (p3."IsDeleted")) AND ('False' OR (p3."TenantId" = '1'))
) AS t2 ON p."Id" = t2."ProductId"
WHERE (('False' OR NOT (p."IsDeleted")) AND ('False' OR (p."TenantId" = '1'))) AND (p."CreationTime" >= '2021-09-10T03:00:00.0000000+03:00')
ORDER BY p."Id", t."Id", t0."Id", t1."Id", t2."Id"
```

  
