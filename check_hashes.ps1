# 1) confirm the mirror repo exists (replace path if different)
Test-Path "D:\AATM-mirror-delete-large.git"
Get-ChildItem "D:\AATM-mirror-delete-large.git" -Force | Select-Object Name -First 20

# 2) check each OID and whether it still appears in history
$hashes = @(
"3966b16083d409acd27a2e900f47443a0ca62d48d90565263993b880f22c207",
"26efd13568b27c5247b777b1077d0e3bbc7d6b50a13cb65d71a5e0fd35e2f776",
"b8887f45d7f56d422334283d799ccbf459ff6196115dedb752dc0559df2ad80b",
"8aeff3d2d509aa6f33d13437c6d45c61e7271b8609917ba852e7ae5f0e89a540",
"c4a44ed077ad1d570ba64039b4782ab936de9bb7d4e5f972327026934758d3a7",
"06dd25acb29ba97b0db4b01645583c5e924b134e3a29e76ac5e5ab71d63764b7",
"2567a043f0ae08f94a773d9a15c799147236391486259493c83c87e9a72bf7b3",
"02970eea25e25790e3390dff92b526e9a4a4c5dafe4ba00c1873d15b7d410c8d",
"93a14ee9b6351b1512420a5d03955f5a20de8b758628641c46176e324c2a7610",
"cc0ff0eb1dc3f5188ae6300faef32bf5beeba4bdd6e8e445a9184072096b713b",
"96f52b302b6aaf8711a4c9d1d89f015981beebfb5a4a5b8f03d89b29cb119a54",
"4872664f94fa6e5136aa1b9d1638bad7badd6bc3397d2ccd73bbc31808302601"
)

foreach ($h in $hashes) {
  Write-Host "`n--- Checking $h ---" -ForegroundColor Cyan
  # Does the object exist (will print 'blob' or an error)
  git cat-file -t $h 2>&1 | ForEach-Object { Write-Host $_ }
  # Does the hash map to any path in history?
  git rev-list --objects --all | Select-String $h -SimpleMatch | ForEach-Object { Write-Host $_ }
}