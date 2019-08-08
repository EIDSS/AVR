<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  exclude-result-prefixes="msxsl" >

  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>
  <xsl:strip-space elements="*" />
  <xsl:preserve-space elements="*" />
  <xsl:param name="updateurl"/>

  <xsl:template match="@* | node() ">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>

  <!--
    this template will add <updateurl url="$updateurl" />
    where $updateurl is actual update url which is passed as parameter
  -->
  <xsl:template match="config[not(updateurl)]">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
      <xsl:if test=" '' != $updateurl ">
        <updateurl>
          <xsl:attribute name="url">
            <xsl:text>https://</xsl:text><xsl:value-of select="$updateurl"/>
          </xsl:attribute>
          <xsl:attribute name="reserve">
            <xsl:text>http://</xsl:text><xsl:value-of select="$updateurl"/>
          </xsl:attribute>
        </updateurl>
        <!--<xsl:text>&#xd;</xsl:text>
        <xsl:text>&#xa;</xsl:text>-->
      </xsl:if>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="updateurl">
    <xsl:choose>
      <xsl:when test=" '' != $updateurl ">
        <updateurl>
          <xsl:attribute name="url">
            <xsl:text>https://</xsl:text>
            <xsl:value-of select="$updateurl"/>
          </xsl:attribute>
          <xsl:attribute name="reserve">
            <xsl:text>http://</xsl:text>
            <xsl:value-of select="$updateurl"/>
          </xsl:attribute>
        </updateurl>
      </xsl:when>
      <xsl:otherwise>
        <xsl:copy>
          <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
