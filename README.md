# Shoppers12
 
Evi: 28/02 15:20 
    Ik heb het originele project nog in de github laten staan langs het nieuwe project, omdat de changes in github allemaal in cache files stonden. 

    Vragen:  --> Wat moeten de models van properties hebben? Of mogen we creatief zijn? & Wat is een order line? 

    De models zijn aangemaakt, de migratie is gelukt voor mij, haar het scaffolden van de controllers niet, idk wat hier het probleem is.
    Ik heb de views en controllers niet volledig kunnen scaffolden dus de views heb ik zelf gemaakt. 
    Views: 
        Product:  (enkel admin kan create edit en delete doen)
            Index OK
            Create OK
            Edit OK
            Delete OK
            Details  OK
        Orders:  (klanten zien enkel hun orders die ze al gemaakt hebben zien, ze maken deze automatisch door producten te kopen)
            Index OK
            Edit
            Details (lijst met alle producten, de koper, het verzend adres) OK
            Delete OK
        ProductCategory: (Klanten zien enkel de index, de rest ziet enkel de admin)
            Index OK
            Create OK
            Edit
            Details (lijst met producten van die categorie mss?) OK
            Delete OK
        OrderLines:  (Klanten kunnen de orderlines die binnen komen niet zien, enkel admin, deze kunne alle informatie zien en editten)
            Index OK
            Edit
            Delete OK

    Note: De creates werken nog NIET. Ik had niet zo veel tijd. Er word nog maar 1 prop ddoorgegeven voor te inserten op de create, dit is niet voldende ivbm foreign keys, dit maak ik in het weekend in orde. Op alle paginas staat minimale informatie (enkel naam)