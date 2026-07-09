# Fluidtech Smart Hub Build & Setup Script

$ErrorActionPreference = "Stop"

# Define Paths
$ProjectDir = $PSScriptRoot
$WorkspaceDir = Split-Path -Path $ProjectDir -Parent
$PublishDir = Join-Path -Path $ProjectDir -ChildPath "publish"
$DistZip = Join-Path -Path $WorkspaceDir -ChildPath "FluidtechSmartHub_Distribution.zip"

Write-Host "==============================================" -ForegroundColor Cyan
Write-Host "Building Fluidtech Smart Hub Desktop Application" -ForegroundColor Cyan
Write-Host "==============================================" -ForegroundColor Cyan

# 1. Clean previous build & publish folders
if (Test-Path $PublishDir) {
    Write-Host "Cleaning previous publish folder..." -ForegroundColor Gray
    Remove-Item -Path $PublishDir -Recurse -Force
}
if (Test-Path $DistZip) {
    Write-Host "Cleaning previous distribution ZIP..." -ForegroundColor Gray
    Remove-Item -Path $DistZip -Force
}

# 2. Publish the C# Project
Write-Host "Publishing C# application..." -ForegroundColor Yellow
# We target net10.0-windows, win-x64, framework-dependent (false to self-contain if needed, but win-x64 dependent is smaller and safer)
dotnet publish -c Release -o $PublishDir --self-contained false -r win-x64

# 3. Create Dashboards and Docs folders inside the published folder
$DestDashboardsDir = Join-Path -Path $PublishDir -ChildPath "Dashboards"
$DestDocsDir = Join-Path -Path $PublishDir -ChildPath "Docs"

New-Item -ItemType Directory -Path $DestDashboardsDir -Force | Out-Null
New-Item -ItemType Directory -Path $DestDocsDir -Force | Out-Null

# 4. Copy Dashboards (HTML files)
Write-Host "Gathering HTML Dashboards..." -ForegroundColor Yellow
$SourceHTMLDir = Join-Path -Path $WorkspaceDir -ChildPath "Rashni Lab Setup & Resin\Rashni Lab Setup & Resin -20260709T090957Z-3-001\Rashni Lab Setup & Resin"

if (-not (Test-Path $SourceHTMLDir)) {
    # Fallback to outer folder if nested folder doesn't exist
    $SourceHTMLDir = Join-Path -Path $WorkspaceDir -ChildPath "Rashni Lab Setup & Resin"
}

$HtmlFiles = Get-ChildItem -Path $SourceHTMLDir -Filter "*.html" -Recurse
foreach ($file in $HtmlFiles) {
    $dest = Join-Path -Path $DestDashboardsDir -ChildPath $file.Name
    if (-not (Test-Path $dest)) {
        Write-Host "  Copying dashboard: $($file.Name)" -ForegroundColor Gray
        Copy-Item -Path $file.FullName -Destination $dest -Force
    }
}

# 5. Copy Documents (PDFs, Excel sheets, Word files)
Write-Host "Gathering Documents & Spreadsheets..." -ForegroundColor Yellow

# A. Source Resin Offer documents
$SourceResinDir = Join-Path -Path $WorkspaceDir -ChildPath "Resin Offer-07-26"
if (Test-Path $SourceResinDir) {
    $ResinFiles = Get-ChildItem -Path $SourceResinDir -Include "*.pdf","*.xlsx","*.docx" -Recurse
    foreach ($file in $ResinFiles) {
        if ($file.Name -notlike "~$*") { # Skip Excel temporary files
            Write-Host "  Copying resin doc: $($file.Name)" -ForegroundColor Gray
            Copy-Item -Path $file.FullName -Destination (Join-Path -Path $DestDocsDir -ChildPath $file.Name) -Force
        }
    }
}

# B. Source Lab setup guidelines, log sheets, and other references
$SourceLabDocsDir = Join-Path -Path $WorkspaceDir -ChildPath "Rashni Lab Setup & Resin\Rashni Lab Setup & Resin -20260709T090957Z-3-001\Rashni Lab Setup & Resin"
if (-not (Test-Path $SourceLabDocsDir)) {
    $SourceLabDocsDir = Join-Path -Path $WorkspaceDir -ChildPath "Rashni Lab Setup & Resin"
}

if (Test-Path $SourceLabDocsDir) {
    $LabFiles = Get-ChildItem -Path $SourceLabDocsDir -Include "*.pdf","*.xlsx","*.docx" -Recurse
    foreach ($file in $LabFiles) {
        if ($file.Name -notlike "~$*") { # Skip Excel temporary files
            Write-Host "  Copying lab doc: $($file.Name)" -ForegroundColor Gray
            Copy-Item -Path $file.FullName -Destination (Join-Path -Path $DestDocsDir -ChildPath $file.Name) -Force
        }
    }
}

# 6. Verify compiled files and copy core assets
Write-Host "Validating published files..." -ForegroundColor Yellow
if (Test-Path (Join-Path -Path $PublishDir -ChildPath "FluidtechSmartHub.exe")) {
    Write-Host "Build Succeeded! Executable found." -ForegroundColor Green
} else {
    Write-Error "Build Failed: Executable not found in publish directory."
}

# 7. Create distribution ZIP
Write-Host "Packaging distribution ZIP for customer sharing..." -ForegroundColor Yellow
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($PublishDir, $DistZip)
Write-Host "Successfully packaged distribution zip at: $DistZip" -ForegroundColor Green

Write-Host "==============================================" -ForegroundColor Green
Write-Host "Setup Completed Successfully!" -ForegroundColor Green
Write-Host "==============================================" -ForegroundColor Green
