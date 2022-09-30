# RAS

Recycle and Survival

### Peraturan Collaborasi
Biar Project Game RAS bersih dan gampang.
Yang melanggar peraturan ini gk bakal diterima Pull Requestnya.

1. Commit code changes-nya sedikit - sedikit jangan banyak - banyak. Misalnya commit "Player buka pintu pake mouse" 👍 yang lebih spesifik trus nambah 1 file C# doang ini bagus 👍... Jangan 🚫 commit "Player Physics" yang general trus nambah 300 file C# 🚫
2. Sebelum Pull Request bersihkan dulu code changes yang udah dibikin dari hal - hal yg tidak berguna misalnya comments, dependency, dan lain - lain yang tidak berhubungan dengan hal yang telah anda buat.
3. JANGAN import asset langsung semuanya diimport masuk ke project. Jadi bikin project Unity dulu khusus buat uji coba assetnya kemudian diseleksi mana yang dibutuhkan mana yang tidak. Pilih sebagian asset yang dibutuhkan kemudian Export, trus Import ke Project RAS.
4. SINGLE RESPONSIBILITY PRINCIPLE. Maksudnya sebuah Class C# hanya punya 1 tanggung jawab. Contohnya Class Player, dapat mengubah nama player atau mengatur jumlah defense player ini bagus 👍. Jangan 🚫 bikin Class Player trus class ini mengatur nama atau stats dari Goblin King sama temen temennya. 
