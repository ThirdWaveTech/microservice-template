# __NAME__

A `crux` service layer

In order to use this template you have 2 options, install the warmup gem globally on your system via
gem install warmup, or use warmup after executing bundle install on the repository. Sample usage below.

:Sample usage if warmup is installed globally:

warmup addTemplateFolder MicroService c:\**PathToRepositories**\Microservice.Template\src

Then simply go to your root directory where you keep your projects and execute

warmup MicroService PaymentService

:Sample usage if warmup is not installed globally: 

warmup %FULL_PATH_TO_REPOSITORY% PaymentService

This will create a folder named PaymentService with all __NAME__ tokens replaced with "PaymentService".