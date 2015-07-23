########################### 
# General aliases 
########################### 
alias ll='ls -la'
alias bedit='start ~/.profile' 
alias bsource='source ~/.profile' 
alias code='cd /c/dev/git' 
alias vs='([[ ! -d "Source" ]] && start *.sln) || start Source/*.sln' 
alias cls='clear'

alias pis='cd /c/dev/git/PartnerIntegrationService'
alias pop='cd /c/dev/git/PartnerOrderPortal'


###########################
# Git command aliases
###########################
alias gs='git status'
alias gd='git diff'
alias ga='git add --all .'
alias gc='git commit -m'
alias gco='git checkout'
alias gk='git fetch origin; git remote prune origin; gitk &'
alias gka='git fetch origin; git remote prune origin; gitk --all &'
alias gp='git pull'
#alias gh='github'
alias grom='git fetch; git rebase origin/master'
alias gmt='git mergetool'
alias td='cmd "/C/Users/vnd-SSmith/bin/tdiff.bat" &'
alias tc='cmd "/C/Users/vnd-SSmith/bin/tcommit.bat" &'


###########################
# bash functions
###########################
function ed() {
  "C:\Program Files (x86)\Notepad++\notepad++.exe" $1 &
}

function tfs(){
  if [ -d .git ] || git rev-parse --git-dir > /dev/null 2>&1; then
    remote=$1

    if [ -z $remote ]
    then
      remote=origin
    fi
    url=$(git remote show $remote | grep "Fetch URL" | cut -c 14- | sed -r -e 's/\w+@/http:\/\//' -e '
    s/\.git$//' -e 's/\.com:/.com\//' -e 's/^\s*//')

    platform=$(uname)

    if [[ $platform == Cygwin* || $platform == MINGW* ]]; then
      opencmd=start
    elif [[ $platform == Darwin* ]]; then
      opencmd=open
    fi

    $opencmd $url
  else
    echo 'Not in a Git repository'
  fi
}


###########################
# change the ls directory color
###########################
#LS_COLORS="di=01;36:"
#export LS_COLORS