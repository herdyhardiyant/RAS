# RAS

`Unity 2021.3.12f1`

Recycle and Survival

### Peraturan Collaborasi
Biar Project Game RAS bersih dan gampang.

1. Commit code changes-nya sedikit - sedikit jangan banyak - banyak. Misalnya commit "Player buka pintu pake mouse" 👍 yang lebih spesifik trus nambah 1 file C# doang ini bagus... Jangan commit "Player Physics" yang general trus nambah 300 file C#
3. JANGAN import asset langsung semuanya diimport masuk ke project. Jadi bikin project Unity dulu khusus buat uji coba assetnya kemudian diseleksi mana yang dibutuhkan mana yang tidak. Pilih sebagian asset yang dibutuhkan kemudian Export, trus Import ke Project RAS.
3. Bikin Class yang punya satu tanggung jawab. Maksudnya sebuah Class C# hanya punya 1 tanggung jawab. Contohnya Class Player, dapat mengubah nama player atau mengatur jumlah defense player ini bagus. Jangan  bikin Class Player trus class ini mengatur nama atau stats dari Goblin King sama temen temennya. 
