# BrabantPongASP
- Zes tabellen zijn gemaakt.
  - Er zit al identity in het project.
  - Speler heeft een één-op-één relatie met club en speler heeft ook een één-op-één relatie met ranking.
  - De delete is een soft delete die items verbergt in Speler, Club en Ranking.
  - Er zijn permanente links naar Speler, Club en Ranking.
  - Er zijn sorteermogelijkheden bij Club en Ranking.
  - De Create bij Speler doet moeilijk, bij Club en Ranking werken de Creates.
  - Er zijn enkelvoudige selects die niet de ID weergeven, maar de Rankingnaam en Clubnaam. (Bij de create van Speler).
  - Seeders zijn gemaakt in dbinitializer, maar deze doen het blijkbaar nog niet.
  - Ik wou ook een meer-op-meer relatie voor Scheidsrechter en Toernooi, met als tussentabel Toernooischeidsrechter.
  - Ook deze hebben permanente links, maar de creates werken hier nog niet, dus met die laatste drie tabellen kun je nog niet zoveel.
