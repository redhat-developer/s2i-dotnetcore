package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;



import io.swagger.annotations.*;
import java.util.Objects;


public class UserFavorite   {
  
  private Integer id = null;
  private String jsonData = null;
  private String name = null;

  /**
   * Primary Key
   **/
  public UserFavorite id(Integer id) {
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
   * Saved search
   **/
  public UserFavorite jsonData(String jsonData) {
    this.jsonData = jsonData;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Saved search")
  @JsonProperty("JsonData")
  public String getJsonData() {
    return jsonData;
  }
  public void setJsonData(String jsonData) {
    this.jsonData = jsonData;
  }

  /**
   * Context Name
   **/
  public UserFavorite name(String name) {
    this.name = name;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Context Name")
  @JsonProperty("Name")
  public String getName() {
    return name;
  }
  public void setName(String name) {
    this.name = name;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    UserFavorite userFavorite = (UserFavorite) o;
    return Objects.equals(id, userFavorite.id) &&
        Objects.equals(jsonData, userFavorite.jsonData) &&
        Objects.equals(name, userFavorite.name);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, jsonData, name);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class UserFavorite {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    jsonData: ").append(toIndentedString(jsonData)).append("\n");
    sb.append("    name: ").append(toIndentedString(name)).append("\n");
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

