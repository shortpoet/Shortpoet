#!/bin/bash

# variables
DateToday=`date +"%Y_%m_%d"`

gitrepo="https://github.com/shortpoet/Shorpoet"
webappname="shortpoet-test"
rg="ShortpoetTestResGrp"
{
# Create a resource group.
echo =================================================================================
echo = Creating Resource group
echo =================================================================================
az group create --location northcentralus --name $rg

# Create an App Service plan in STANDARD tier (minimum required by deployment slots).
echo =================================================================================
echo = Creating App Service Plan
echo =================================================================================
az appservice plan create --name $webappname --resource-group $rg --sku S1

# Create a web app.
echo =================================================================================
echo = Creating Web App
echo =================================================================================
az webapp create --name $webappname --resource-group $rg \
--plan $webappname

#Create a deployment slot with the name "staging".
echo =================================================================================
echo = Creating Deployment Slot \"Staging\"
echo =================================================================================
az webapp deployment slot create --name $webappname --resource-group $rg \
--slot staging

# Deploy sample code to "staging" slot from GitHub.
echo =================================================================================
echo = Deploy code from github to Slot \"Staging\"
echo =================================================================================
az webapp deployment source config --name $webappname --resource-group $rg \
--slot staging --repo-url $gitrepo --branch test --manual-integration

# Copy the result of the following command into a browser to see the staging slot.
echo =================================================================================
echo = Browse to Deployment Slot \"Staging\"
echo =================================================================================
echo http://$webappname-staging.azurewebsites.net

# Swap the verified/warmed up staging slot into production.
echo =================================================================================
echo = Swapping verified/warmed up Slot \"Staging\" into production
echo =================================================================================
az webapp deployment slot swap --name $webappname --resource-group $rg \
--slot staging

# Copy the result of the following command into a browser to see the web app in the production slot.
echo =================================================================================
echo = Browse to Deployment Slot \"Staging\"
echo =================================================================================
echo http://$webappname.azurewebsites.net
} > ./logs/$webappname$DateToday
