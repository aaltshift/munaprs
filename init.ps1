"Copying configuration files"
cp build\local_properties.rb.customize build\local_properties.rb
cp build\tasks\configuration_db.rb.customize build\tasks\configuration_db.rb

"Creating the remote link to developwithpassion code base"
git remote rm jp
git remote add jp git://github.com/developwithpassion/munaprp.git
