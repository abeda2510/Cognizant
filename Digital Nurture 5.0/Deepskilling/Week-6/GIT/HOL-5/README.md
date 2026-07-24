# HOL-5 - Clean Up and Push Back to Remote Git

## Objective

To understand how to clean up a Git repository and push local changes to a remote Git repository.

## Topics Covered

- Verifying Git repository status
- Checking available branches
- Configuring a remote repository
- Pulling changes from remote
- Pushing local changes to remote
- Verifying changes in the remote repository

## Steps Performed

### 1. Verify Master Branch is Clean

Checked the current repository status:

```bash
git status
```

The working tree was clean:

```text
On branch master
nothing to commit, working tree clean
```

### 2. List Available Branches

```bash
git branch -a
```

This displayed the available Git branches.

### 3. Check Remote Repository

```bash
git remote -v
```

Initially, no remote repository was configured.

### 4. Configure Remote Repository

Connected the local `GitDemo` repository to the remote GitHub repository:

```bash
git remote add origin <remote-repository-url>
```

Verified the remote configuration:

```bash
git remote -v
```

### 5. Pull Changes from Remote Repository

When working with an existing remote repository, changes can be synchronized using:

```bash
git pull origin master
```

The remote repository used for this hands-on was initially empty, so there were no existing remote changes to pull before the first push.

### 6. Push Local Changes to Remote Repository

Pushed the local `master` branch to the remote repository:

```bash
git push -u origin master
```

The push completed successfully and the local `master` branch was configured to track `origin/master`.

### 7. Verify Remote Repository

The remote GitHub repository was checked to verify that the committed project files were successfully pushed and available remotely.

## Output Screenshots

The `Outputs` folder contains screenshots demonstrating the hands-on execution:

1. `01-Clean-Status-And-Branches.png`
2. `02-Push-To-Remote-Success.png`
3. `03-Remote-Repository-Verified.png`

## Result

Successfully verified the clean state of the Git repository, checked available branches, configured a remote repository, pushed the local commits to GitHub, and verified the changes in the remote repository.

## Conclusion

This hands-on demonstrated how to synchronize a local Git repository with a remote repository and verify that local changes are successfully reflected remotely.
