# SimCityGP

I wonder how this works. 

basic git commands :

	git clone <github link ending in .git> 		-- makes a copy of the github repo as a child directory
	git add <file(s)> 							-- add files ready for commit
	git commit -m "Commit text"					-- commits files to local repo (before its uploaded) with description
	git push									-- Push your local version to master version on GitHub 
	git pull									-- Pull an updated Repo from GitHub 


Example workflow:

	Get initial repo:
	git clone https://github.com/davidpox/SimCityGP.git
	
	<< YOU CHANGE README.md>>
	
	git add README.md
	git commit -m "Updated README.md"
	git push