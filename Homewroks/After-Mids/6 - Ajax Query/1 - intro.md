//make partial view in SHARED folder
//return your partial view from any controller which you want.
//render/load your partial view in a any cshtml file through js file.
//clicking to any button from view, call goes in js file.
//jahan pe clicked button ki id k against function k andr jaya jata
//aur url se dekha jata k data kis controller se aa ra.
//url me usi view ka controller ata jis view se click huwa ho button pe



1 - shared>add>view>NewsPartialView
2 - HomeController>action method> return partialView("NewsPartialView", some DBdata)     //may be you need to made classes here.
3 - Render it in any view with button in any view and manage its click call in js file.

//class-Task:
Get data in view on clicking any button through Jquery and print it in table form.
- see these uploaded files
- Happy coding



