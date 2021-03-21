# Test1
## Test-Projesi

### An  E-Commerce website are online portal that facilitate online transactions of goods and services through means of the transfer of information and funds over the Internet.

### Lesson 37
###### Linq daki sorguları her tablo için tekrar tekrar yazmaya gerek bırakmıyor
###### Kod tekrarını önlüyor.
###### Sıkı bağlı kod yazmıyoruz. Esneklik sağlıyor.

### Lesson 38
###### Repository, bellekteki nesnelerin bir koleksiyonu gibi davranmalıdır.
###### Update yada save metodu yazılmamalıdır. Çünkü proje complex hale gelince ileride sorun teşkil eder.
###### Peki save ve update olayını nasıl halledeceğiz.
###### Bunun için --unit of work-- çağıracağız.

### Lesson 53
###### we are using unit of work as dependency injection but we have not added that to our project so far.  

### Lesson 74
###### Now the first thing will change is the bindproperty. This will be the menu item but here with menu item we actually need to display in a dropdown the foodtype and a list of available categories for the user to select so far that it won't be just a menu item because inside menu item we only have one category and one food type. But we need a dropdown with a list of category and food type. So in this case a single model cannot meet our requirements for what we want to display inside the upsert when it was sad situation arises. --> You can add multiple properties here but the correct way to do so is create a new viewmodel. So that brings us to a new terminology. ViewModel. ViewModel can be defined as a collection of models.

### Lesson 75
###### Menuitem Upsert post fonksiyonunun yazılması. Resim ile ilgili işlemlerin nasıl gerçekleştiğini gösteriyor.

### Lesson 105
###### Startup.cs class'a services.AddSession() ve app.UseSession(); i ekledik