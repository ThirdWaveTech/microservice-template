*This top section of the README describes how to get started with the template and should be deleted after the template has been generated.*

***
# Microservice.Template

A solution template for quickly creating a microservice using the following technologies:

* [NancyFx](http://nancyfx.org)
* [NServiceBus](http://particular.net/nservicebus)
* [StructureMap](http://structuremap.github.io/)
* [NHibernate](http://nhibernate.info/) / [Fluent NHibernate](http://www.fluentnhibernate.org/)
* [Crux](https://github.com/scardetto/Crux)
* [FluentMigrator](https://github.com/schambers/fluentmigrator)
* [AutoMapper](http://automapper.org/)
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
* [Refit](https://github.com/paulcbetts/refit)

At [Third Wave Technology](http://www.thirdwave.it), we use this template as a starting point when we create a new service layer application for our clients.

## Getting Started

This template is designed to be used with [WarmuP](https://github.com/chucknorris/warmup), a command-line utility that substitutes a single replacement token across file and folder names, as well as within the individual files within a Git repo or local directory.

### Prerequisites

To use WarmuP, you will need to install some prerequisites:

* [Ruby 2.1](https://github.com/scardetto/physique/blob/master/RUBY_SETUP.md) or later
* Install the WarmuP gem by running the following:

    ```
    $ gem install warmup
    ```

### Generating the Solution

* Open a command prompt and `cd` into the directory where you want to create the solution.
* Using an administrative command prompt, type the following:

    ```
    $ warmup https://github.com/ThirdWaveTech/Microservice.Template <<Your Solution Name>>
    ```

For example, let's say you were creating a microservice to manage users. You might enter something like this:

```
$ warmup https://github.com/ThirdWaveTech/Microservice.Template MyCompany.UserService
$ cd MyCompany.UserService
```

## What's in the Template?

The solution contains several projects.  At first glance it might seem like a lot, but this is by design.  While it's certainly possible to combine them into fewer more coarse-grained projects, we decided to keep them separate to emphasize the separation of concerns behind the architecture. This template is only a starting point so feel free to modify it as you see fit. :)

### Project Breakdown

*NOTE: The \_\_NAME\_\_ token will be replaced with your solution name by WarmuP.*

#### \_\_NAME\_\_.Api

A NancyFx application which provides an HTTP API to your clients.  This app is where you will implement the synchronous communication to your service.

#### \_\_NAME\_\_.MessageBus

An NServiceBus host application. This app provides asynchronous, durable communication into your service.

#### \_\_NAME\_\_.Domain

This library is where you implement your domain logic using [Domain Driven Design](http://en.wikipedia.org/wiki/Domain-driven_design) principles. Common implementations of the DDD patterns are provided by the Crux library. 

#### \_\_NAME\_\_.Domain.Persistence

This library is where you implement your NHibernate ORM mappings and configuration.

#### \_\_NAME\_\_.Database

This library contains your FluentMigrator migrations.  It also has some SQL scripts that can be used with Physique to create an efficient [developer workflow](https://github.com/scardetto/physique/blob/master/FLUENT_MIGRATOR.md).

#### \_\_NAME\_\_.Api.Client

A library that can be used by .NET clients to call your HTTP service. It uses Refit to create lightweight interfaces.

#### \_\_NAME\_\_.MessageBus.Client

A library that can be used by .NET clients to call your service via message queueing.

#### \_\_NAME\_\_.Models

A library containing the strongly-typed model objects used by the API.

#### \_\_NAME\_\_.Messages

A library containing the messages that will be consumed and published by the message bus.

### Build and Deployment Support

The `rake` tasks provided by Physique allow you to easily create a continuous integration build for the solution on your favorite CI server.

The build scripts are also pre-configured to package and publish the applications to [Octopus Deploy](https://octopusdeploy.com).  If you are not using Octopus to deploy your apps, you can simply remove that configuration from your `Rakefile`.

## Known Issues

There is an issue in the database drop script when providing a dotted replacement token. (i.e. "MyCompany.MyService"). SQLCMD.exe which runs the scripts, doesn't like dotted parameters.  If you use a dotted name, remember to remove the dots in the database name in the generated connection strings and Rakefile.

## Support

Feel free to contact me [@scardetto](https://twitter.com/scardetto) if you have any questions.

If you are looking for professional consulting services to help you build your service layer, [contact us](http://www.thirdwave.it/schedule-a-consultation/) for a free consultation.

## Contributing

1. Fork it ( https://github.com/thirdwavetech/microservice.template/fork )
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create a new Pull Request

*The following is the actual README that you should include in the solution generated by the template.*

***
# __NAME__

Describe this service.

## Prerequisites

* [Ruby 2.1](https://github.com/scardetto/physique/blob/master/RUBY_SETUP.md) or later.
* Microsoft SQL Server or SQL Server Express Edition.
* IIS (not Express)

## Building the Solution

This solution uses the [Physique](https://github.com/scardetto/physique) Ruby gem to build and deploy the solution. To build and run the tests included in the template, type the following:

```
$ gem install bundler    # Install the required bundler gem.
$ bundle install         # This will install the gems required for the build.
$ bundle exec rake test  # This will build the solution and run all of the unit and integration tests.
```

This solution also includes a suite of acceptance tests that perform black-box testing against the service interface.  The easiest way to run the acceptance tests is to run the solution in the Visual Studio debugger and the type the following:

```
$ bundle exec rake acceptance
```

## Building the Database

To rebuild the database locally using the migrations, run the following from the command-prompt:

```
$ bundle exec db:rebuild
```

For more information about working with databases, check out this [handy guide](https://github.com/scardetto/physique/blob/master/FLUENT_MIGRATOR.md).

## Other Build Tasks

The solution comes with several other build tasks, to see the list of tasks available to you, type the following at the command-line:

```
$ bundle exec rake --tasks
```
