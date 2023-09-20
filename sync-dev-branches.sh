branches=("dev-Nicha" "dev-Oliver" "dev-Lily" "dev-Alvina" "dev-Nate")

git checkout main &&
git pull origin main

for branch in "${branches[@]}"; do
    git checkout "$branch" &&
    git pull &&
    if git merge main; then
        git add . &&
        git push
    else
        echo "Merge into $branch failed. Continuing with the next branch."
        git stash
    fi
    git add . &&
    git push
done

git checkout main
