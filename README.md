> If you're here, you're probably looking for [Karata.Web](https://karatagame.herokuapp.com), the modern version built on [.NET 6](https://get.dot.net/6). ~Unfortunately, that version is closed-source~ [Here it is](https://github.com/sixpeteunder/karata). This is only an early version that ran as a console application.

# Karata.Console
[WIP] The card game we all know and love.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to publish the application and runtime into a self-contained package.

### Pre-requisites

1. Git
2. [.NET Core 3.1.1](https://dotnet.microsoft.com/download) 

### Installing

A step by step series of examples that tell you how to get a development env running

Clone the repo to your local machine:

```
git clone https://github.com/sixpeteunder/Karata.Console
```

Enter the project directory:

```
cd karata
```

Run the app:

```
dotnet run
```

Development environment is set up!

Follow the prompts to play the game.

## Deployment

To build an executable binary for your platform, run:

```
dotnet publish -r <RID>
```

I will update this with notes on how to create a self-contained installer for the app.

Replace `<RID>` with the [specific Runtime Identifier](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) for your platform. 

## Built With

* [.NET Core 3.1.1](https://dotnet.microsoft.com/download) - Framework 
* [NuGet](https://www.nuget.org) - Dependency Management

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

See the list of [contributors](https://github.com/sixpeteunder/karata/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to everyone this project kept up at night, directly and indirectly.
* Many thanks to my small, under-appreciated army of logicians, testers and critiques.
