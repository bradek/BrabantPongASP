# BrabantPongASP

## Volledig
- Drie tabellen zijn gemaakt.
  - Er zit al identity in het project.
  - Speler heeft een één-op-één relatie met club en speler heeft ook een één-op-één relatie met ranking.
  - De delete is een soft delete die items verbergt in Speler, Club en Ranking.
  - Er zijn permanente links naar Speler, Club en Ranking.
  - Er zijn sorteermogelijkheden bij Club en Ranking.
  - Bij Club en Ranking werken de Creates.
  - Er zijn enkelvoudige selects die niet de ID weergeven, maar de Rankingnaam en Clubnaam.
  - Seeders zijn gemaakt in dbinitializer, deze werken inmiddels wel.
  - Ook deze hebben permanente links, maar de creates werken hier nog niet, dus met die laatste drie tabellen kun je nog niet zoveel.
  - Github link correct

## Niet gelukt of onvolledig:
  - Ik wou ook een meer-op-meer relatie voor Scheidsrechter en Toernooi, met als tussentabel Toernooischeidsrechter, maar daar ben ik in gefaald. Ik heb dus wel 2 relaties, maar deze zijn één-op-meer.
  - De index view bij Speler doet moeilijk toont twee zaken niet, namelijk de clubnaam en rankingnaam. Ze staan wel in de details en de selects ernaar werken correct.
  
