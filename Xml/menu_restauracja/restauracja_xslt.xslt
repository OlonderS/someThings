<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body STYLE="font-family:Arial, helvetica, sans-serif; font-size:12pt; background-color:#EEEEEE">
        <h1>MENU</h1>      
        <h3>Śniadania</h3>
        <ul>
          <xsl:for-each select = "menu/grupa">
            <xsl:if test="tytuł='Śniadania' ">
              <xsl:for-each select = "danie">
                <li><xsl:value-of select = "nazwa"/> (<xsl:value-of select = "@cena"/> <xsl:value-of select = "@waluta"/>) (<xsl:value-of select = "@czas_oczekiwania"/>)</li>
                <ul>
                  <xsl:for-each select = "opcja">
                    <li><xsl:value-of select = "Onazwa"/></li>
                    <ul>
                      <xsl:for-each select = "dodatek">
                        <li><xsl:value-of select = "Dnazwa"/> (<xsl:value-of select = "@cena"/><xsl:value-of select = "@waluta"/>)</li>
                      </xsl:for-each>
                    </ul>
                  </xsl:for-each>
                </ul> 
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </ul>
        <h3>Obiady</h3>
        <ul>
          <xsl:for-each select = "menu/grupa">
            <xsl:if test="tytuł='Obiady' ">
              <xsl:for-each select = "danie">
                <li><xsl:value-of select = "nazwa"/> (<xsl:value-of select = "@cena"/> <xsl:value-of select = "@waluta"/>) (<xsl:value-of select = "@czas_oczekiwania"/>)</li>
                <ul>
                  <xsl:for-each select = "opcja">
                    <li><xsl:value-of select = "Onazwa"/></li>
                    <ul>
                      <xsl:for-each select = "dodatek">
                        <li> <xsl:value-of select = "Dnazwa"/> (<xsl:value-of select = "@cena"/><xsl:value-of select = "@waluta"/>)</li>
                      </xsl:for-each>
                    </ul>
                  </xsl:for-each>
                </ul> 
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </ul>   
        <h3>Zupy</h3>
        <ul>
          <xsl:for-each select = "menu/grupa">
            <xsl:if test="tytuł='Zupy' ">
              <xsl:for-each select = "danie">
                <li><xsl:value-of select = "nazwa"/> (<xsl:value-of select = "@cena"/> <xsl:value-of select = "@waluta"/>) (<xsl:value-of select = "@czas_oczekiwania"/>)</li>
                <ul>
                  <xsl:for-each select = "opcja">
                    <li><xsl:value-of select = "Onazwa"/></li>
                    <ul>
                      <xsl:for-each select = "dodatek">
                        <li> <xsl:value-of select = "Dnazwa"/> (<xsl:value-of select = "@cena"/><xsl:value-of select = "@waluta"/>)</li>
                      </xsl:for-each>
                    </ul>
                  </xsl:for-each>
                </ul> 
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </ul>
        <h3>Kolacje</h3>
        <ul>
          <xsl:for-each select = "menu/grupa">
            <xsl:if test="tytuł='Kolacje' ">
              <xsl:for-each select = "danie">
                <li><xsl:value-of select = "nazwa"/> (<xsl:value-of select = "@cena"/> <xsl:value-of select = "@waluta"/>) (<xsl:value-of select = "@czas_oczekiwania"/>)</li>
                <ul>
                  <xsl:for-each select = "opcja">
                    <li><xsl:value-of select = "Onazwa"/></li>
                    <ul>
                      <xsl:for-each select = "dodatek">
                        <li> <xsl:value-of select = "Dnazwa"/> (<xsl:value-of select = "@cena"/><xsl:value-of select = "@waluta"/>)</li>
                      </xsl:for-each>
                    </ul>
                  </xsl:for-each>
                </ul> 
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </ul>  
        <h3>Napoje</h3>
        <ul>
          <xsl:for-each select = "menu/grupa">
            <xsl:if test="tytuł='Napoje' ">
              <xsl:for-each select = "danie">
                <li><xsl:value-of select = "nazwa"/> (<xsl:value-of select = "@cena"/> <xsl:value-of select = "@waluta"/>) (<xsl:value-of select = "@czas_oczekiwania"/>)</li>
                <ul>
                  <xsl:for-each select = "opcja">
                    <li><xsl:value-of select = "Onazwa"/></li>
                    <ul>
                      <xsl:for-each select = "dodatek">
                        <li> <xsl:value-of select = "Dnazwa"/> (<xsl:value-of select = "@cena"/><xsl:value-of select = "@waluta"/>)</li>
                      </xsl:for-each>
                    </ul>
                  </xsl:for-each>
                </ul> 
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </ul>
      </body>
      <footer>
        <a href="https://www.restauracjanr1.pl">Odwiedź naszą stronę!</a>
      </footer>
    </html>
  </xsl:template>
</xsl:stylesheet>