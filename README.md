# Дипломски рад - Анализа имплементације и перформанси различитих објектно-релационих мапера 

Милош Гравара - RA60/2019

## Увод 

Репозиторијум намењен за реализацију дипломског рада који се бави упоредном анализом имплементације и перформанси различитих објектно-релационих мапера. 
Алати који су одабрани за анализу: _**Entity Framework**_ - **_C#_**, **_Hibernate_** - **_Java_**, _**SQLAlchemy**_ - _**Python**_ 
Идеја је да се истражи начин имплементације сваког од наведених алата и да се упореде њихове перформансе са основним библиотекама за комуникацију са базама података у одговарајућим програмским језицима. 
За систем за управљање базом података одабран је _**MySQL**_ због своје доступности и једноставности за коришћење и креирање базе података, као и због своје широке примене у развоју модерних информационих система. 

## Тестно окружење 

### Хардверске спецификаије 

Процесор: AMD Ryzen 7 5800H, 16 језгара, 3.2 GHz
РАМ: 16 GB, 3200 MHz
Хард-диск: Samsung PM991A M.2 512GB

### Софтверске спецификације

Оперативни систем: Windows 10 Pro 64-bit
Систем за управљање базом података: MySQL 8.0.34
Алати за објектно-релационо мапирање:
 - Entity Framework Core 7.0.9
 - Hibernate Core 6.2.6
 - SQLAlchemy 1.4.49

## Шема базе података

За потребе тестирања наведених алата, коришћена је шема базе података друштвене мреже. Основни ентитети који чине шему су: **Корисник**, **Профил**, **Објава** и **Таг**.
- **Корисник - _User_** представља особу која користи систем или платформу. У основи, то је налог преко кога особа приступа и користи различите услуге или функције платформе.
- **Профил - _Profile_** садржи личне и додатне податке о кориснику. То могу бити информације попут слике профила, контактних информација, биографије и других детаља који помажу у идентификацији или представљању корисника на платформи. У овој табели се налази страни кључ "корисник_ид" који директно повезује профил са конкретним корисником.
- Сваки **Корисник** има један и само један **Профил** који садржи додатне информације о њему. Профил је повезан са корисником преко страног кључа ***user_id*. Ова веза један према један осигурава да сваки корисник има јединствен профил на платформи.
- **Објава - _Post_** представља текстуални садржај који корисник дели на платформи. Свака објава има временску ознаку (тиместамп) која указује на тачно време када је објава креирана или постављена. Ова временска ознака помаже у праћењу и сортирању објава на хронолошкој основи.
- **Ознака (Таг) - _Tag_** представља кључну реч или ознаку која помаже у категоризацији и претрази садржаја. Тагови омогућавају корисницима да брзо пронађу сродне објаве или чланке на основу интересовања или теме.
- **Таг_Објава - _Post_Tag_** представљају везу између објава и одговарајућих тагова. Ова табела омогућава свакој објави да има више тагова и, истовремено, сваки таг може бити придружен више објавама. Ова веза помаже у ефикасној организацији и претрази садржаја на платформи.
Разлог због ког је одабрана ова шема базе података је да се омогући увид у механизме  објектно релационих мапера за мапирање веза између ентита шеме базе података и веза између објеката у одговарајућим програмским језицима. 
Такође, услед постојања веза између ентитета, ствара се могућност тестирања перформанси алата у реализацији комплексних упита.

### Подаци 

Табеле _**Users**_ и _**Profiles**_ попуњене су са по 80 хиљада насумичних података, при чему је акценат био на поштовању задатих ограничења шеме базе података. 
Табеле _**Posts**_, _**Tags**_ i _**Posts_Tags**_ попуњене су са по приближно 100 хиљада насумичних података и обраћена је посебна пажња да подаци буду разноврсно распоређени како би се створили реални услови тестирања перформанси. Ово се односи на чињеницу да поједини корисници платформе могу имати више објава и ознака везаних за своје објаве, док неки корисници уопште немају објаве или поједине објаве немају ознаке.     
