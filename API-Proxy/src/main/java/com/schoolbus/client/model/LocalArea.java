package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.Region;



import io.swagger.annotations.*;
import java.util.Objects;


public class LocalArea   {
  
  private Integer id = null;
  private Region region = null;

  /**
   * Primary Key
   **/
  public LocalArea id(Integer id) {
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
  public LocalArea region(Region region) {
    this.region = region;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Region")
  public Region getRegion() {
    return region;
  }
  public void setRegion(Region region) {
    this.region = region;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    LocalArea localArea = (LocalArea) o;
    return Objects.equals(id, localArea.id) &&
        Objects.equals(region, localArea.region);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, region);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class LocalArea {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    region: ").append(toIndentedString(region)).append("\n");
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

