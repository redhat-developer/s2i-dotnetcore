package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.City;
import com.schoolbus.client.model.SchoolDistrict;



import io.swagger.annotations.*;
import java.util.Objects;


public class Owner   {
  
  private Integer id = null;
  private Integer fleetNum = null;
  private String mcCode = null;
  private String fleetSize = null;
  private Integer hasBuses = null;
  private String diff = null;
  private String leaseSize = null;
  private Integer hasDups = null;
  private SchoolDistrict schoolDistrict = null;
  private City city = null;

  /**
   * Primary Key
   **/
  public Owner id(Integer id) {
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
  public Owner fleetNum(Integer fleetNum) {
    this.fleetNum = fleetNum;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("FleetNum")
  public Integer getFleetNum() {
    return fleetNum;
  }
  public void setFleetNum(Integer fleetNum) {
    this.fleetNum = fleetNum;
  }

  /**
   **/
  public Owner mcCode(String mcCode) {
    this.mcCode = mcCode;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("MCCode")
  public String getMcCode() {
    return mcCode;
  }
  public void setMcCode(String mcCode) {
    this.mcCode = mcCode;
  }

  /**
   **/
  public Owner fleetSize(String fleetSize) {
    this.fleetSize = fleetSize;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("FleetSize")
  public String getFleetSize() {
    return fleetSize;
  }
  public void setFleetSize(String fleetSize) {
    this.fleetSize = fleetSize;
  }

  /**
   **/
  public Owner hasBuses(Integer hasBuses) {
    this.hasBuses = hasBuses;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("HasBuses")
  public Integer getHasBuses() {
    return hasBuses;
  }
  public void setHasBuses(Integer hasBuses) {
    this.hasBuses = hasBuses;
  }

  /**
   **/
  public Owner diff(String diff) {
    this.diff = diff;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Diff")
  public String getDiff() {
    return diff;
  }
  public void setDiff(String diff) {
    this.diff = diff;
  }

  /**
   **/
  public Owner leaseSize(String leaseSize) {
    this.leaseSize = leaseSize;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("LeaseSize")
  public String getLeaseSize() {
    return leaseSize;
  }
  public void setLeaseSize(String leaseSize) {
    this.leaseSize = leaseSize;
  }

  /**
   **/
  public Owner hasDups(Integer hasDups) {
    this.hasDups = hasDups;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("HasDups")
  public Integer getHasDups() {
    return hasDups;
  }
  public void setHasDups(Integer hasDups) {
    this.hasDups = hasDups;
  }

  /**
   **/
  public Owner schoolDistrict(SchoolDistrict schoolDistrict) {
    this.schoolDistrict = schoolDistrict;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("SchoolDistrict")
  public SchoolDistrict getSchoolDistrict() {
    return schoolDistrict;
  }
  public void setSchoolDistrict(SchoolDistrict schoolDistrict) {
    this.schoolDistrict = schoolDistrict;
  }

  /**
   **/
  public Owner city(City city) {
    this.city = city;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("City")
  public City getCity() {
    return city;
  }
  public void setCity(City city) {
    this.city = city;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    Owner owner = (Owner) o;
    return Objects.equals(id, owner.id) &&
        Objects.equals(fleetNum, owner.fleetNum) &&
        Objects.equals(mcCode, owner.mcCode) &&
        Objects.equals(fleetSize, owner.fleetSize) &&
        Objects.equals(hasBuses, owner.hasBuses) &&
        Objects.equals(diff, owner.diff) &&
        Objects.equals(leaseSize, owner.leaseSize) &&
        Objects.equals(hasDups, owner.hasDups) &&
        Objects.equals(schoolDistrict, owner.schoolDistrict) &&
        Objects.equals(city, owner.city);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, fleetNum, mcCode, fleetSize, hasBuses, diff, leaseSize, hasDups, schoolDistrict, city);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class Owner {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    fleetNum: ").append(toIndentedString(fleetNum)).append("\n");
    sb.append("    mcCode: ").append(toIndentedString(mcCode)).append("\n");
    sb.append("    fleetSize: ").append(toIndentedString(fleetSize)).append("\n");
    sb.append("    hasBuses: ").append(toIndentedString(hasBuses)).append("\n");
    sb.append("    diff: ").append(toIndentedString(diff)).append("\n");
    sb.append("    leaseSize: ").append(toIndentedString(leaseSize)).append("\n");
    sb.append("    hasDups: ").append(toIndentedString(hasDups)).append("\n");
    sb.append("    schoolDistrict: ").append(toIndentedString(schoolDistrict)).append("\n");
    sb.append("    city: ").append(toIndentedString(city)).append("\n");
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

