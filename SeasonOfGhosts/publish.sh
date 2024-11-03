dotnet publish
ssh ubuntu@57.129.70.141 'sudo systemctl stop season-of-ghosts.service'

scp -r ./bin/Release/net8.0/publish/* ubuntu@57.129.70.141:/var/www/spot_ubuntu/

ssh ubuntu@57.129.70.141 'sudo systemctl start season-of-ghosts.service'

