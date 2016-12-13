package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;



import io.swagger.annotations.*;
import java.util.Objects;


public class CCWData   {
  
  private Integer id = null;
  private Integer modelYear = null;
  private String rateClass = null;
  private String cvIPDecal = null;
  private Integer fleetUnitNo = null;
  private Integer GVW = null;
  private String body = null;
  private String rebuiltStatus = null;
  private java.util.Date cvIPExpiry = null;
  private Integer netWt = null;
  private String model = null;
  private String fuel = null;
  private Integer seatingCapacity = null;
  private String colour = null;

  /**
   * Primary Key
   **/
  public CCWData id(Integer id) {
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
   * Vehicle Year
   **/
  public CCWData modelYear(Integer modelYear) {
    this.modelYear = modelYear;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Vehicle Year")
  @JsonProperty("ModelYear")
  public Integer getModelYear() {
    return modelYear;
  }
  public void setModelYear(Integer modelYear) {
    this.modelYear = modelYear;
  }

  /**
   **/
  public CCWData rateClass(String rateClass) {
    this.rateClass = rateClass;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("RateClass")
  public String getRateClass() {
    return rateClass;
  }
  public void setRateClass(String rateClass) {
    this.rateClass = rateClass;
  }

  /**
   **/
  public CCWData cvIPDecal(String cvIPDecal) {
    this.cvIPDecal = cvIPDecal;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("CVIPDecal")
  public String getCvIPDecal() {
    return cvIPDecal;
  }
  public void setCvIPDecal(String cvIPDecal) {
    this.cvIPDecal = cvIPDecal;
  }

  /**
   **/
  public CCWData fleetUnitNo(Integer fleetUnitNo) {
    this.fleetUnitNo = fleetUnitNo;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("FleetUnitNo")
  public Integer getFleetUnitNo() {
    return fleetUnitNo;
  }
  public void setFleetUnitNo(Integer fleetUnitNo) {
    this.fleetUnitNo = fleetUnitNo;
  }

  /**
   **/
  public CCWData GVW(Integer GVW) {
    this.GVW = GVW;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("GVW")
  public Integer getGVW() {
    return GVW;
  }
  public void setGVW(Integer GVW) {
    this.GVW = GVW;
  }

  /**
   **/
  public CCWData body(String body) {
    this.body = body;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Body")
  public String getBody() {
    return body;
  }
  public void setBody(String body) {
    this.body = body;
  }

  /**
   **/
  public CCWData rebuiltStatus(String rebuiltStatus) {
    this.rebuiltStatus = rebuiltStatus;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("RebuiltStatus")
  public String getRebuiltStatus() {
    return rebuiltStatus;
  }
  public void setRebuiltStatus(String rebuiltStatus) {
    this.rebuiltStatus = rebuiltStatus;
  }

  /**
   **/
  public CCWData cvIPExpiry(java.util.Date cvIPExpiry) {
    this.cvIPExpiry = cvIPExpiry;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("CVIPExpiry")
  public java.util.Date getCvIPExpiry() {
    return cvIPExpiry;
  }
  public void setCvIPExpiry(java.util.Date cvIPExpiry) {
    this.cvIPExpiry = cvIPExpiry;
  }

  /**
   **/
  public CCWData netWt(Integer netWt) {
    this.netWt = netWt;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("NetWt")
  public Integer getNetWt() {
    return netWt;
  }
  public void setNetWt(Integer netWt) {
    this.netWt = netWt;
  }

  /**
   **/
  public CCWData model(String model) {
    this.model = model;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Model")
  public String getModel() {
    return model;
  }
  public void setModel(String model) {
    this.model = model;
  }

  /**
   **/
  public CCWData fuel(String fuel) {
    this.fuel = fuel;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Fuel")
  public String getFuel() {
    return fuel;
  }
  public void setFuel(String fuel) {
    this.fuel = fuel;
  }

  /**
   **/
  public CCWData seatingCapacity(Integer seatingCapacity) {
    this.seatingCapacity = seatingCapacity;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("SeatingCapacity")
  public Integer getSeatingCapacity() {
    return seatingCapacity;
  }
  public void setSeatingCapacity(Integer seatingCapacity) {
    this.seatingCapacity = seatingCapacity;
  }

  /**
   **/
  public CCWData colour(String colour) {
    this.colour = colour;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Colour")
  public String getColour() {
    return colour;
  }
  public void setColour(String colour) {
    this.colour = colour;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    CCWData ccWData = (CCWData) o;
    return Objects.equals(id, ccWData.id) &&
        Objects.equals(modelYear, ccWData.modelYear) &&
        Objects.equals(rateClass, ccWData.rateClass) &&
        Objects.equals(cvIPDecal, ccWData.cvIPDecal) &&
        Objects.equals(fleetUnitNo, ccWData.fleetUnitNo) &&
        Objects.equals(GVW, ccWData.GVW) &&
        Objects.equals(body, ccWData.body) &&
        Objects.equals(rebuiltStatus, ccWData.rebuiltStatus) &&
        Objects.equals(cvIPExpiry, ccWData.cvIPExpiry) &&
        Objects.equals(netWt, ccWData.netWt) &&
        Objects.equals(model, ccWData.model) &&
        Objects.equals(fuel, ccWData.fuel) &&
        Objects.equals(seatingCapacity, ccWData.seatingCapacity) &&
        Objects.equals(colour, ccWData.colour);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, modelYear, rateClass, cvIPDecal, fleetUnitNo, GVW, body, rebuiltStatus, cvIPExpiry, netWt, model, fuel, seatingCapacity, colour);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class CCWData {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    modelYear: ").append(toIndentedString(modelYear)).append("\n");
    sb.append("    rateClass: ").append(toIndentedString(rateClass)).append("\n");
    sb.append("    cvIPDecal: ").append(toIndentedString(cvIPDecal)).append("\n");
    sb.append("    fleetUnitNo: ").append(toIndentedString(fleetUnitNo)).append("\n");
    sb.append("    GVW: ").append(toIndentedString(GVW)).append("\n");
    sb.append("    body: ").append(toIndentedString(body)).append("\n");
    sb.append("    rebuiltStatus: ").append(toIndentedString(rebuiltStatus)).append("\n");
    sb.append("    cvIPExpiry: ").append(toIndentedString(cvIPExpiry)).append("\n");
    sb.append("    netWt: ").append(toIndentedString(netWt)).append("\n");
    sb.append("    model: ").append(toIndentedString(model)).append("\n");
    sb.append("    fuel: ").append(toIndentedString(fuel)).append("\n");
    sb.append("    seatingCapacity: ").append(toIndentedString(seatingCapacity)).append("\n");
    sb.append("    colour: ").append(toIndentedString(colour)).append("\n");
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

