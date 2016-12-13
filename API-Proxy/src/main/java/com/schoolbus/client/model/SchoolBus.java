package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.CCWData;
import com.schoolbus.client.model.Owner;



import io.swagger.annotations.*;
import java.util.Objects;


public class SchoolBus   {
  
  private Integer id = null;
  private Owner owner = null;
  private String CRNO = null;
  private Integer lesseeNumber = null;
  private java.util.Date licenseExpiryDate = null;
  private java.util.Date permitExpiryDate = null;
  private java.util.Date nextInspectionDate = null;
  private Integer manYear = null;
  private String sbCap = null;
  private String mcCap = null;
  private String wcCap = null;
  private java.util.Date lastUpdate = null;
  private String plate = null;
  private CCWData ccWData = null;

  /**
   * Primary Key
   **/
  public SchoolBus id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(example = "null", required = true, value = "Primary Key")
  @JsonProperty("Id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  /**
   **/
  public SchoolBus owner(Owner owner) {
    this.owner = owner;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Owner")
  public Owner getOwner() {
    return owner;
  }
  public void setOwner(Owner owner) {
    this.owner = owner;
  }

  /**
   * CR Number.
   **/
  public SchoolBus CRNO(String CRNO) {
    this.CRNO = CRNO;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "CR Number.")
  @JsonProperty("CRNO")
  public String getCRNO() {
    return CRNO;
  }
  public void setCRNO(String CRNO) {
    this.CRNO = CRNO;
  }

  /**
   **/
  public SchoolBus lesseeNumber(Integer lesseeNumber) {
    this.lesseeNumber = lesseeNumber;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("LesseeNumber")
  public Integer getLesseeNumber() {
    return lesseeNumber;
  }
  public void setLesseeNumber(Integer lesseeNumber) {
    this.lesseeNumber = lesseeNumber;
  }

  /**
   **/
  public SchoolBus licenseExpiryDate(java.util.Date licenseExpiryDate) {
    this.licenseExpiryDate = licenseExpiryDate;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("LicenseExpiryDate")
  public java.util.Date getLicenseExpiryDate() {
    return licenseExpiryDate;
  }
  public void setLicenseExpiryDate(java.util.Date licenseExpiryDate) {
    this.licenseExpiryDate = licenseExpiryDate;
  }

  /**
   **/
  public SchoolBus permitExpiryDate(java.util.Date permitExpiryDate) {
    this.permitExpiryDate = permitExpiryDate;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("PermitExpiryDate")
  public java.util.Date getPermitExpiryDate() {
    return permitExpiryDate;
  }
  public void setPermitExpiryDate(java.util.Date permitExpiryDate) {
    this.permitExpiryDate = permitExpiryDate;
  }

  /**
   **/
  public SchoolBus nextInspectionDate(java.util.Date nextInspectionDate) {
    this.nextInspectionDate = nextInspectionDate;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("NextInspectionDate")
  public java.util.Date getNextInspectionDate() {
    return nextInspectionDate;
  }
  public void setNextInspectionDate(java.util.Date nextInspectionDate) {
    this.nextInspectionDate = nextInspectionDate;
  }

  /**
   **/
  public SchoolBus manYear(Integer manYear) {
    this.manYear = manYear;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("ManYear")
  public Integer getManYear() {
    return manYear;
  }
  public void setManYear(Integer manYear) {
    this.manYear = manYear;
  }

  /**
   **/
  public SchoolBus sbCap(String sbCap) {
    this.sbCap = sbCap;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("SB_Cap")
  public String getSbCap() {
    return sbCap;
  }
  public void setSbCap(String sbCap) {
    this.sbCap = sbCap;
  }

  /**
   **/
  public SchoolBus mcCap(String mcCap) {
    this.mcCap = mcCap;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("MC_Cap")
  public String getMcCap() {
    return mcCap;
  }
  public void setMcCap(String mcCap) {
    this.mcCap = mcCap;
  }

  /**
   **/
  public SchoolBus wcCap(String wcCap) {
    this.wcCap = wcCap;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("WC_Cap")
  public String getWcCap() {
    return wcCap;
  }
  public void setWcCap(String wcCap) {
    this.wcCap = wcCap;
  }

  /**
   **/
  public SchoolBus lastUpdate(java.util.Date lastUpdate) {
    this.lastUpdate = lastUpdate;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("LastUpdate")
  public java.util.Date getLastUpdate() {
    return lastUpdate;
  }
  public void setLastUpdate(java.util.Date lastUpdate) {
    this.lastUpdate = lastUpdate;
  }

  /**
   **/
  public SchoolBus plate(String plate) {
    this.plate = plate;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Plate")
  public String getPlate() {
    return plate;
  }
  public void setPlate(String plate) {
    this.plate = plate;
  }

  /**
   **/
  public SchoolBus ccWData(CCWData ccWData) {
    this.ccWData = ccWData;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("CCWData")
  public CCWData getCcWData() {
    return ccWData;
  }
  public void setCcWData(CCWData ccWData) {
    this.ccWData = ccWData;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    SchoolBus schoolBus = (SchoolBus) o;
    return Objects.equals(id, schoolBus.id) &&
        Objects.equals(owner, schoolBus.owner) &&
        Objects.equals(CRNO, schoolBus.CRNO) &&
        Objects.equals(lesseeNumber, schoolBus.lesseeNumber) &&
        Objects.equals(licenseExpiryDate, schoolBus.licenseExpiryDate) &&
        Objects.equals(permitExpiryDate, schoolBus.permitExpiryDate) &&
        Objects.equals(nextInspectionDate, schoolBus.nextInspectionDate) &&
        Objects.equals(manYear, schoolBus.manYear) &&
        Objects.equals(sbCap, schoolBus.sbCap) &&
        Objects.equals(mcCap, schoolBus.mcCap) &&
        Objects.equals(wcCap, schoolBus.wcCap) &&
        Objects.equals(lastUpdate, schoolBus.lastUpdate) &&
        Objects.equals(plate, schoolBus.plate) &&
        Objects.equals(ccWData, schoolBus.ccWData);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, owner, CRNO, lesseeNumber, licenseExpiryDate, permitExpiryDate, nextInspectionDate, manYear, sbCap, mcCap, wcCap, lastUpdate, plate, ccWData);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class SchoolBus {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    owner: ").append(toIndentedString(owner)).append("\n");
    sb.append("    CRNO: ").append(toIndentedString(CRNO)).append("\n");
    sb.append("    lesseeNumber: ").append(toIndentedString(lesseeNumber)).append("\n");
    sb.append("    licenseExpiryDate: ").append(toIndentedString(licenseExpiryDate)).append("\n");
    sb.append("    permitExpiryDate: ").append(toIndentedString(permitExpiryDate)).append("\n");
    sb.append("    nextInspectionDate: ").append(toIndentedString(nextInspectionDate)).append("\n");
    sb.append("    manYear: ").append(toIndentedString(manYear)).append("\n");
    sb.append("    sbCap: ").append(toIndentedString(sbCap)).append("\n");
    sb.append("    mcCap: ").append(toIndentedString(mcCap)).append("\n");
    sb.append("    wcCap: ").append(toIndentedString(wcCap)).append("\n");
    sb.append("    lastUpdate: ").append(toIndentedString(lastUpdate)).append("\n");
    sb.append("    plate: ").append(toIndentedString(plate)).append("\n");
    sb.append("    ccWData: ").append(toIndentedString(ccWData)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

