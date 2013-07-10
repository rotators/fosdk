#include Makefile.vars

all:

clean:
	rm -f Client/FOnline.log
	rm -f Client/data/cache/*/*
	rm -f Client/data/cache/*.cache

	rm -f Server/maps/*.fomapb
	rm -f Server/scripts/*.fosp
	rm -f Server/scripts/*.fosb

wipe: clean
	rm -f Server/save/bans/*.txt
	rm -f Server/save/clients/*.client
	rm -f Server/save/clients/*.client_deleted
	rm -f Server/save/*.fo
	rmdir --ignore-fail-on-non-empty Client/data/cache/*/
	rmdir --ignore-fail-on-non-empty Client/data/cache/

#

gitignore:
	tail */.gitignore */.gitignore */*/.gitignore */*/*/.gitignore */*/*/*/.gitignore */*/*/*/*/.gitignore 2>/dev/null
