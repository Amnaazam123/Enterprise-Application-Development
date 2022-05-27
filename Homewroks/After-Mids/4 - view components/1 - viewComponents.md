view components are similar to partial views but more powerful. view components do not use model binding but depends on data provided when calling it.

-If we need to write some common code, we use partial views, we need to write the whole code(calling the database, getting the data, binding the model), everything in the partial view
but in viewcomponent we do not need to write entire things.(e.g dynamic menu, shopping cart etc)

-Create a folder named as "Components" just like Controller.
-Like in controller folder we have controller classes, in components folder we have ViewComponent classes. Follow suffix naming convention too (studentViewComponent.cs).
-Inherit your class from ViewComponent. ( : ViewComponent - using Microsoft.AspNetCore.Mvc)

views > shared > make folder "Components" (This is just like views folder now in controller) > make folder "student"(name of your viewcomponent) > make one cshtml file always named as "Default.cshtml" (this will be your viewcomponent)

![image](https://user-images.githubusercontent.com/71166016/170659880-7d166453-1e1c-40b9-b4a9-b59f5a8f38ba.png)


vie components include 2 files(cs file and cshtml file)
cs file => for class attributes or any data record to be shown
cshtml file => to show your view component look

index.cshtml => any file whic will call viewComponent.

index.cshtml se call gai, wo viewcomponent ki cshtml wali file)(Default.cshtml) me aya, wahan se wo @Model se compontne wali file me gya.
