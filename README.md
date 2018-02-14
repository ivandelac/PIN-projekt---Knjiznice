# PIN-projekt---Knjiznice
Ovo je management aplikacija za knjižnice kako bi se omogućila kontrola nad građom koju imaju i članovima.
Korištene su sljedeće tehnologije/metode:

 -  ASP.NET Core MVC framework 1.1 

 -  Entity Framework 
 
 -  RAZER
 
 -  LINQ
 
 -  Bootstrap
 
 
Aplikacija je realizirana u 3 layera:
 
 1) Web layer - oblikovanje informacija koje se prikazuju korisnicima
 
       - Models - svojevrsni "view" modeli za indeksirane i detaljnije prikaze knjižnične građe, članova i informacija 
                         o knjižnicama -> svaki model ima pripadajući View
 
 2) Data layer (KnjizniceData) - class library sa entity modelima , migracijama i interface-ima
                              
       - u interfacima (IClan, IPosudba....) su definirane metode koje kontroleri pozivaju ovisno o korisnikovom                                    requestu
                               
 3) Service layer (KnjizniceServisi) - class library sa servisima u kojima su detaljno opisane metode (business logic) koje se preko    
                                       interface-a (data layer) injectaju u pripadajuće kontrolere.
