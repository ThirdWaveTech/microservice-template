require 'cruxrake'

CruxRake::Solution.new do |s|
  s.file = 'src/__NAME__.sln'

  s.database do |db|
    db.instance = ENV['DATABASE_SERVER'] || 'localhost'
    db.name = ENV['DATABASE_NAME'] || '__NAME__'
    db.project = '__NAME__.Database'
  end

  s.octopus_deploy do |octo|
    octo.server = 'http://build/nuget/packages'
    octo.api_key = ENV['OCTOPUS_API_KEY']
    
    octo.deploy_app do |app|
      app.name = 'database'
      app.type = :console
      app.project = '__NAME__.Database'

      app.with_metadata do |m|
        m.description = '__NAME__ Database Migrations'
        m.authors = 'Third Wave Technology'
      end
    end

    octo.deploy_app do |app|
      app.name = 'web'
      app.type = :website
      app.project = '__NAME__.WebApi'

      app.with_metadata do |m|
        m.description = '__NAME__ Web API'
        m.authors = 'Third Wave Technology'
      end
    end

    octo.deploy_app do |app|
      app.name = 'messagebus'
      app.type = :console
      app.project = '__NAME__.MessageBus'

      app.with_metadata do |m|
        m.description = '__NAME__ Message Bus'
        m.authors = 'Third Wave Technology'
      end
    end
  end
end
