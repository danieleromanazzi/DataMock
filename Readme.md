# Data Mock
With this library you can fill your application with random data.

> Tired of having to launch your application to set its UI?
> 
> Tell me you've never written code to fill a list and test your application's performance.
> 
> Or do you need to show your application and have not yet implemented the data access layer?

**All of this can now be part of your past!**

Are you a picky developer?
Don't worry! You can customize this.

## Features
- Auto generate **word** and you can customize the number of word and lenght.
- Auto generate **phrase** and **paragraph** and customize the quantity.
- Auto generate **number**.
- Auto choose **value of your enumerable**.
- Auto generate **image** with pixel art and you can customize size and dimension of rectangle.
- Auto generate **boolean** value.
- Auto generate **Colors** into your application.
- Auto generate a **collection** and fill item them.

## See it in Action!
### Console application with mock data
![Console application with mock data](/Documentation/ConsoleDataMockExecute.gif)

### WPF application a design time with mock data 
![WPF application a design time with mock data ](/Documentation/WpfDataMockDesignTime.gif)

### Execute your application with mock data
![Execute your application with mock data](/Documentation/WpfDataMockExecute.gif)

## How to use into Console application
```csharp
var persons = Activator.CreateMock.Configure()
                .AddBehavior<StringBehavior>(new WordsBehavior() { Lenght = 5, Number = 2 })
                .AddBehavior<CollectionBehavior>(new CollectionBehavior { Lenght = 3 })
                .MockingData<Persons>();

foreach (var person in persons.Items)
{
    System.Console.WriteLine(person.ToString());
    System.Console.WriteLine("");
}
```
[See the example in demo application](/Demo/DataMock.Console.Demo/Program.cs)

## How to use into WPF application

### Design Time
It's very easy. You can set your DataContext with alias default namespace 'd:' using the Mock class and set in Type property your bind Viewmodel

```csharp
d:DataContext="{dt:Mock Type={x:Type vm:MainViewModel}, ConfigurationName='DataMock.ini'}"
```

### Run application with data mock

```xml
<Window.DataContext>
    <dt:Mock Type="{x:Type vm:MainViewModel}" ConfigurationName="DataMock.ini" />
</Window.DataContext>
```

[See the example in demo application](/Demo/DataMock.Wpf.Demo/Views/MainView.xaml)

## How to configure
Cooming soon

