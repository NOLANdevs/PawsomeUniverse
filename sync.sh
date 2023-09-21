git pull origin main &&
git pull
if git merge main; then
    git add . &&
    git push
else
    echo "Merge failed." &&
    git stash &&
    exit 1
fi
git add . &&
git push
